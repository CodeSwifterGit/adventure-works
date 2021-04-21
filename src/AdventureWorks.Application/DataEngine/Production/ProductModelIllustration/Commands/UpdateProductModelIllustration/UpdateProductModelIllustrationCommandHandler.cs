using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.UpdateProductModelIllustration
{
    public partial class UpdateProductModelIllustrationCommandHandler : IRequestHandler<UpdateProductModelIllustrationCommand, ProductModelIllustrationLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductModelIllustrationsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductModelIllustrationCommandHandler(IAdventureWorksContext context,
            ProductModelIllustrationsQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<ProductModelIllustrationLookupModel> Handle(UpdateProductModelIllustrationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModelIllustrations
                .SingleAsync(c => c.ProductModelID == request.RequestTarget.ProductModelID && c.IllustrationID == request.RequestTarget.IllustrationID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductModelIllustration, UpdateProductModelIllustrationCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductModelIllustration), JsonConvert.SerializeObject(new { request.RequestTarget.ProductModelID, request.RequestTarget.IllustrationID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductModelIllustrations.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductModelIllustrations.SingleAsync(c => c.ProductModelID == request.RequestTarget.ProductModelID && c.IllustrationID == request.RequestTarget.IllustrationID, cancellationToken);

            await _mediator.Publish(new ProductModelIllustrationUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductModelIllustration, ProductModelIllustrationLookupModel>(entity);
        }
    }
}
