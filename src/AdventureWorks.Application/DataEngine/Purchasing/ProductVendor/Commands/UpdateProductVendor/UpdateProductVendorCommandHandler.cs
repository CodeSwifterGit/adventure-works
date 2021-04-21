using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.UpdateProductVendor
{
    public partial class UpdateProductVendorCommandHandler : IRequestHandler<UpdateProductVendorCommand, ProductVendorLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductVendorsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductVendorCommandHandler(IAdventureWorksContext context,
            ProductVendorsQueryManager queryManager,
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

        public async Task<ProductVendorLookupModel> Handle(UpdateProductVendorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductVendors
                .SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.VendorID == request.RequestTarget.VendorID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductVendor, UpdateProductVendorCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductVendor), JsonConvert.SerializeObject(new { request.RequestTarget.ProductID, request.RequestTarget.VendorID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductVendors.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductVendors.SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.VendorID == request.RequestTarget.VendorID, cancellationToken);

            await _mediator.Publish(new ProductVendorUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductVendor, ProductVendorLookupModel>(entity);
        }
    }
}
