using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.UpdateVendorContact
{
    public partial class UpdateVendorContactCommandHandler : IRequestHandler<UpdateVendorContactCommand, VendorContactLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly VendorContactsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateVendorContactCommandHandler(IAdventureWorksContext context,
            VendorContactsQueryManager queryManager,
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

        public async Task<VendorContactLookupModel> Handle(UpdateVendorContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VendorContacts
                .SingleAsync(c => c.VendorID == request.RequestTarget.VendorID && c.ContactID == request.RequestTarget.ContactID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.VendorContact, UpdateVendorContactCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(VendorContact), JsonConvert.SerializeObject(new { request.RequestTarget.VendorID, request.RequestTarget.ContactID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.VendorContacts.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.VendorContacts.SingleAsync(c => c.VendorID == request.RequestTarget.VendorID && c.ContactID == request.RequestTarget.ContactID, cancellationToken);

            await _mediator.Publish(new VendorContactUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.VendorContact, VendorContactLookupModel>(entity);
        }
    }
}
