using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.UpdateCustomerAddress
{
    public partial class UpdateCustomerAddressCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, CustomerAddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly CustomerAddressesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateCustomerAddressCommandHandler(IAdventureWorksContext context,
            CustomerAddressesQueryManager queryManager,
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

        public async Task<CustomerAddressLookupModel> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CustomerAddresses
                .SingleAsync(c => c.CustomerID == request.RequestTarget.CustomerID && c.AddressID == request.RequestTarget.AddressID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.CustomerAddress, UpdateCustomerAddressCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerAddress), JsonConvert.SerializeObject(new { request.RequestTarget.CustomerID, request.RequestTarget.AddressID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.CustomerAddresses.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.CustomerAddresses.SingleAsync(c => c.CustomerID == request.RequestTarget.CustomerID && c.AddressID == request.RequestTarget.AddressID, cancellationToken);

            await _mediator.Publish(new CustomerAddressUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.CustomerAddress, CustomerAddressLookupModel>(entity);
        }
    }
}
