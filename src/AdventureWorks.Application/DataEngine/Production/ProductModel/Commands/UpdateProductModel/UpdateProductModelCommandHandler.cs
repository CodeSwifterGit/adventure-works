using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.UpdateProductModel
{
    public partial class UpdateProductModelCommandHandler : IRequestHandler<UpdateProductModelCommand, ProductModelLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductModelsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductModelCommandHandler(IAdventureWorksContext context,
            ProductModelsQueryManager queryManager,
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

        public async Task<ProductModelLookupModel> Handle(UpdateProductModelCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModels
                .SingleAsync(c => c.ProductModelID == request.RequestTarget.ProductModelID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductModel, UpdateProductModelCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductModel), JsonConvert.SerializeObject(new { request.RequestTarget.ProductModelID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductModels.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductModels.SingleAsync(c => c.ProductModelID == request.RequestTarget.ProductModelID, cancellationToken);

            await _mediator.Publish(new ProductModelUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductModel, ProductModelLookupModel>(entity);
        }
    }
}
