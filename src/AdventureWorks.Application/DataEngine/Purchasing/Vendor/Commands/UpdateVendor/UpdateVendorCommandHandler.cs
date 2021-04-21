using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.UpdateVendor
{
    public partial class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, VendorLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly VendorsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateVendorCommandHandler(IAdventureWorksContext context,
            VendorsQueryManager queryManager,
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

        public async Task<VendorLookupModel> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vendors
                .SingleAsync(c => c.VendorID == request.RequestTarget.VendorID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Vendor, UpdateVendorCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vendor), JsonConvert.SerializeObject(new { request.RequestTarget.VendorID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Vendors.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Vendors.SingleAsync(c => c.VendorID == request.RequestTarget.VendorID, cancellationToken);

            await _mediator.Publish(new VendorUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Vendor, VendorLookupModel>(entity);
        }
    }
}
