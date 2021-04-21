using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.CreateSalesTerritoryHistory
{
    public partial class CreateSalesTerritoryHistoryCommand : BaseSalesTerritoryHistory, IRequest<SalesTerritoryHistoryLookupModel>, IHaveCustomMapping
    {

        public CreateSalesTerritoryHistoryCommand()
        {

        }

        public CreateSalesTerritoryHistoryCommand(BaseSalesTerritoryHistory model, IMapper mapper)
        {
            mapper.Map<BaseSalesTerritoryHistory, CreateSalesTerritoryHistoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesTerritoryHistoryCommand, SalesTerritoryHistoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesTerritoryHistoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesTerritoryHistoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesTerritoryHistoryLookupModel> Handle(CreateSalesTerritoryHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesTerritoryHistoryCommand, Entities.SalesTerritoryHistory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesTerritoryHistories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesTerritoryHistories.FindAsync(new object[] { entity.SalesPersonID, entity.TerritoryID, entity.StartDate }, cancellationToken);

                await _mediator.Publish(new SalesTerritoryHistoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesTerritoryHistory, SalesTerritoryHistoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesTerritoryHistory, CreateSalesTerritoryHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesTerritoryHistoryCommand, Entities.SalesTerritoryHistory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
