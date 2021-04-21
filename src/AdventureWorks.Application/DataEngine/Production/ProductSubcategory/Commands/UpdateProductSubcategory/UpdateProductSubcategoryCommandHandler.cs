using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.UpdateProductSubcategory
{
    public partial class UpdateProductSubcategoryCommandHandler : IRequestHandler<UpdateProductSubcategoryCommand, ProductSubcategoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductSubcategoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductSubcategoryCommandHandler(IAdventureWorksContext context,
            ProductSubcategoriesQueryManager queryManager,
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

        public async Task<ProductSubcategoryLookupModel> Handle(UpdateProductSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductSubcategories
                .SingleAsync(c => c.ProductSubcategoryID == request.RequestTarget.ProductSubcategoryID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductSubcategory, UpdateProductSubcategoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductSubcategory), JsonConvert.SerializeObject(new { request.RequestTarget.ProductSubcategoryID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductSubcategories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductSubcategories.SingleAsync(c => c.ProductSubcategoryID == request.RequestTarget.ProductSubcategoryID, cancellationToken);

            await _mediator.Publish(new ProductSubcategoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductSubcategory, ProductSubcategoryLookupModel>(entity);
        }
    }
}
