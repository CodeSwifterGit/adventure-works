using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.UpdateSpecialOfferProduct
{
    public partial class UpdateSpecialOfferProductCommandHandler : IRequestHandler<UpdateSpecialOfferProductCommand, SpecialOfferProductLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SpecialOfferProductsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSpecialOfferProductCommandHandler(IAdventureWorksContext context,
            SpecialOfferProductsQueryManager queryManager,
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

        public async Task<SpecialOfferProductLookupModel> Handle(UpdateSpecialOfferProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecialOfferProducts
                .SingleAsync(c => c.SpecialOfferID == request.RequestTarget.SpecialOfferID && c.ProductID == request.RequestTarget.ProductID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SpecialOfferProduct, UpdateSpecialOfferProductCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SpecialOfferProduct), JsonConvert.SerializeObject(new { request.RequestTarget.SpecialOfferID, request.RequestTarget.ProductID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SpecialOfferProducts.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SpecialOfferProducts.SingleAsync(c => c.SpecialOfferID == request.RequestTarget.SpecialOfferID && c.ProductID == request.RequestTarget.ProductID, cancellationToken);

            await _mediator.Publish(new SpecialOfferProductUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SpecialOfferProduct, SpecialOfferProductLookupModel>(entity);
        }
    }
}
