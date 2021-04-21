using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.UpdateAddressType
{
    public partial class UpdateAddressTypeCommandHandler : IRequestHandler<UpdateAddressTypeCommand, AddressTypeLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly AddressTypesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateAddressTypeCommandHandler(IAdventureWorksContext context,
            AddressTypesQueryManager queryManager,
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

        public async Task<AddressTypeLookupModel> Handle(UpdateAddressTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.AddressTypes
                .SingleAsync(c => c.AddressTypeID == request.RequestTarget.AddressTypeID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.AddressType, UpdateAddressTypeCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AddressType), JsonConvert.SerializeObject(new { request.RequestTarget.AddressTypeID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.AddressTypes.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.AddressTypes.SingleAsync(c => c.AddressTypeID == request.RequestTarget.AddressTypeID, cancellationToken);

            await _mediator.Publish(new AddressTypeUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.AddressType, AddressTypeLookupModel>(entity);
        }
    }
}
