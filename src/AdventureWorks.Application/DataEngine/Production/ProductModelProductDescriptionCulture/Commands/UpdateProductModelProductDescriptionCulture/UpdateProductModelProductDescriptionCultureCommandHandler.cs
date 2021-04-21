using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.UpdateProductModelProductDescriptionCulture
{
    public partial class UpdateProductModelProductDescriptionCultureCommandHandler : IRequestHandler<UpdateProductModelProductDescriptionCultureCommand, ProductModelProductDescriptionCultureLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductModelProductDescriptionCulturesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductModelProductDescriptionCultureCommandHandler(IAdventureWorksContext context,
            ProductModelProductDescriptionCulturesQueryManager queryManager,
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

        public async Task<ProductModelProductDescriptionCultureLookupModel> Handle(UpdateProductModelProductDescriptionCultureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModelProductDescriptionCultures
                .SingleAsync(c => c.ProductModelID == request.RequestTarget.ProductModelID && c.ProductDescriptionID == request.RequestTarget.ProductDescriptionID && c.CultureID == request.RequestTarget.CultureID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductModelProductDescriptionCulture, UpdateProductModelProductDescriptionCultureCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductModelProductDescriptionCulture), JsonConvert.SerializeObject(new { request.RequestTarget.ProductModelID, request.RequestTarget.ProductDescriptionID, request.RequestTarget.CultureID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductModelProductDescriptionCultures.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductModelProductDescriptionCultures.SingleAsync(c => c.ProductModelID == request.RequestTarget.ProductModelID && c.ProductDescriptionID == request.RequestTarget.ProductDescriptionID && c.CultureID == request.RequestTarget.CultureID, cancellationToken);

            await _mediator.Publish(new ProductModelProductDescriptionCultureUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureLookupModel>(entity);
        }
    }
}
