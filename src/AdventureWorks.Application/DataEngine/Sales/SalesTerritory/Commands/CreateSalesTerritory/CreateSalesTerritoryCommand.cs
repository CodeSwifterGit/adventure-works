using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.CreateSalesTerritory
{
    public partial class CreateSalesTerritoryCommand : BaseSalesTerritory, IRequest<SalesTerritoryLookupModel>, IHaveCustomMapping
    {

        public CreateSalesTerritoryCommand()
        {

        }

        public CreateSalesTerritoryCommand(BaseSalesTerritory model, IMapper mapper)
        {
            mapper.Map<BaseSalesTerritory, CreateSalesTerritoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesTerritoryCommand, SalesTerritoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesTerritoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesTerritoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesTerritoryLookupModel> Handle(CreateSalesTerritoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesTerritoryCommand, Entities.SalesTerritory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesTerritories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesTerritories.FindAsync(new object[] { entity.TerritoryID }, cancellationToken);

                await _mediator.Publish(new SalesTerritoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesTerritory, SalesTerritoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesTerritory, CreateSalesTerritoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesTerritoryCommand, Entities.SalesTerritory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
