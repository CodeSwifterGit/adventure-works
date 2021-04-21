using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.CreateContactType
{
    public partial class CreateContactTypeCommand : BaseContactType, IRequest<ContactTypeLookupModel>, IHaveCustomMapping
    {

        public CreateContactTypeCommand()
        {

        }

        public CreateContactTypeCommand(BaseContactType model, IMapper mapper)
        {
            mapper.Map<BaseContactType, CreateContactTypeCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateContactTypeCommand, ContactTypeLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ContactTypesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ContactTypesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ContactTypeLookupModel> Handle(CreateContactTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateContactTypeCommand, Entities.ContactType>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ContactTypes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ContactTypes.FindAsync(new object[] { entity.ContactTypeID }, cancellationToken);

                await _mediator.Publish(new ContactTypeCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ContactType, ContactTypeLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseContactType, CreateContactTypeCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateContactTypeCommand, Entities.ContactType>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
