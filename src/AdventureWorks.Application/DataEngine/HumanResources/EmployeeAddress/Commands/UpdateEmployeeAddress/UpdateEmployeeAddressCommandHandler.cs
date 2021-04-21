using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.UpdateEmployeeAddress
{
    public partial class UpdateEmployeeAddressCommandHandler : IRequestHandler<UpdateEmployeeAddressCommand, EmployeeAddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly EmployeeAddressesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateEmployeeAddressCommandHandler(IAdventureWorksContext context,
            EmployeeAddressesQueryManager queryManager,
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

        public async Task<EmployeeAddressLookupModel> Handle(UpdateEmployeeAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeAddresses
                .SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID && c.AddressID == request.RequestTarget.AddressID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.EmployeeAddress, UpdateEmployeeAddressCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EmployeeAddress), JsonConvert.SerializeObject(new { request.RequestTarget.EmployeeID, request.RequestTarget.AddressID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.EmployeeAddresses.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.EmployeeAddresses.SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID && c.AddressID == request.RequestTarget.AddressID, cancellationToken);

            await _mediator.Publish(new EmployeeAddressUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.EmployeeAddress, EmployeeAddressLookupModel>(entity);
        }
    }
}
