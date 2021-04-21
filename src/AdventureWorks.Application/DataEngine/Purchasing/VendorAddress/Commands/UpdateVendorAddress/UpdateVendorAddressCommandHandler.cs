using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.UpdateVendorAddress
{
    public partial class UpdateVendorAddressCommandHandler : IRequestHandler<UpdateVendorAddressCommand, VendorAddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly VendorAddressesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateVendorAddressCommandHandler(IAdventureWorksContext context,
            VendorAddressesQueryManager queryManager,
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

        public async Task<VendorAddressLookupModel> Handle(UpdateVendorAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VendorAddresses
                .SingleAsync(c => c.VendorID == request.RequestTarget.VendorID && c.AddressID == request.RequestTarget.AddressID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.VendorAddress, UpdateVendorAddressCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(VendorAddress), JsonConvert.SerializeObject(new { request.RequestTarget.VendorID, request.RequestTarget.AddressID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.VendorAddresses.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.VendorAddresses.SingleAsync(c => c.VendorID == request.RequestTarget.VendorID && c.AddressID == request.RequestTarget.AddressID, cancellationToken);

            await _mediator.Publish(new VendorAddressUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.VendorAddress, VendorAddressLookupModel>(entity);
        }
    }
}
