using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.UpdateProductDescription
{
    public partial class UpdateProductDescriptionCommandHandler : IRequestHandler<UpdateProductDescriptionCommand, ProductDescriptionLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductDescriptionsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductDescriptionCommandHandler(IAdventureWorksContext context,
            ProductDescriptionsQueryManager queryManager,
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

        public async Task<ProductDescriptionLookupModel> Handle(UpdateProductDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductDescriptions
                .SingleAsync(c => c.ProductDescriptionID == request.RequestTarget.ProductDescriptionID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductDescription, UpdateProductDescriptionCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductDescription), JsonConvert.SerializeObject(new { request.RequestTarget.ProductDescriptionID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductDescriptions.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductDescriptions.SingleAsync(c => c.ProductDescriptionID == request.RequestTarget.ProductDescriptionID, cancellationToken);

            await _mediator.Publish(new ProductDescriptionUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductDescription, ProductDescriptionLookupModel>(entity);
        }
    }
}
