using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.CreateStore
{
    public partial class CreateStoreCommand : BaseStore, IRequest<StoreLookupModel>, IHaveCustomMapping
    {

        public CreateStoreCommand()
        {

        }

        public CreateStoreCommand(BaseStore model, IMapper mapper)
        {
            mapper.Map<BaseStore, CreateStoreCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateStoreCommand, StoreLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly StoresQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                StoresQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<StoreLookupModel> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateStoreCommand, Entities.Store>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Stores.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Stores.FindAsync(new object[] { entity.CustomerID }, cancellationToken);

                await _mediator.Publish(new StoreCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Store, StoreLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseStore, CreateStoreCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateStoreCommand, Entities.Store>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
