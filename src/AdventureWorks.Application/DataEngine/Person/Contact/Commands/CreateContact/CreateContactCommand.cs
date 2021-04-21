using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.CreateContact
{
    public partial class CreateContactCommand : BaseContact, IRequest<ContactLookupModel>, IHaveCustomMapping
    {

        public CreateContactCommand()
        {

        }

        public CreateContactCommand(BaseContact model, IMapper mapper)
        {
            mapper.Map<BaseContact, CreateContactCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateContactCommand, ContactLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ContactsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ContactsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ContactLookupModel> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateContactCommand, Entities.Contact>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Contacts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Contacts.FindAsync(new object[] { entity.ContactID }, cancellationToken);

                await _mediator.Publish(new ContactCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Contact, ContactLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseContact, CreateContactCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateContactCommand, Entities.Contact>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
