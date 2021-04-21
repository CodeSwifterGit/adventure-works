using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.UpdateContact
{
    public partial class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ContactsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateContactCommandHandler(IAdventureWorksContext context,
            ContactsQueryManager queryManager,
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

        public async Task<ContactLookupModel> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts
                .SingleAsync(c => c.ContactID == request.RequestTarget.ContactID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Contact, UpdateContactCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), JsonConvert.SerializeObject(new { request.RequestTarget.ContactID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Contacts.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Contacts.SingleAsync(c => c.ContactID == request.RequestTarget.ContactID, cancellationToken);

            await _mediator.Publish(new ContactUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Contact, ContactLookupModel>(entity);
        }
    }
}
