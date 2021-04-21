using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.UpdateContactType
{
    public partial class UpdateContactTypeCommandHandler : IRequestHandler<UpdateContactTypeCommand, ContactTypeLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ContactTypesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateContactTypeCommandHandler(IAdventureWorksContext context,
            ContactTypesQueryManager queryManager,
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

        public async Task<ContactTypeLookupModel> Handle(UpdateContactTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactTypes
                .SingleAsync(c => c.ContactTypeID == request.RequestTarget.ContactTypeID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ContactType, UpdateContactTypeCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactType), JsonConvert.SerializeObject(new { request.RequestTarget.ContactTypeID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ContactTypes.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ContactTypes.SingleAsync(c => c.ContactTypeID == request.RequestTarget.ContactTypeID, cancellationToken);

            await _mediator.Publish(new ContactTypeUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ContactType, ContactTypeLookupModel>(entity);
        }
    }
}
