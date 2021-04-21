using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.CreateStoreContact
{
    public partial class CreateStoreContactCommand : BaseStoreContact, IRequest<StoreContactLookupModel>, IHaveCustomMapping
    {

        public CreateStoreContactCommand()
        {

        }

        public CreateStoreContactCommand(BaseStoreContact model, IMapper mapper)
        {
            mapper.Map<BaseStoreContact, CreateStoreContactCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateStoreContactCommand, StoreContactLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly StoreContactsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                StoreContactsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<StoreContactLookupModel> Handle(CreateStoreContactCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateStoreContactCommand, Entities.StoreContact>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.StoreContacts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.StoreContacts.FindAsync(new object[] { entity.CustomerID, entity.ContactID }, cancellationToken);

                await _mediator.Publish(new StoreContactCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.StoreContact, StoreContactLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseStoreContact, CreateStoreContactCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateStoreContactCommand, Entities.StoreContact>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
