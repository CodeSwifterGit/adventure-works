using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.CreateSalesPersonQuotaHistory
{
    public partial class CreateSalesPersonQuotaHistoryCommand : BaseSalesPersonQuotaHistory, IRequest<SalesPersonQuotaHistoryLookupModel>, IHaveCustomMapping
    {

        public CreateSalesPersonQuotaHistoryCommand()
        {

        }

        public CreateSalesPersonQuotaHistoryCommand(BaseSalesPersonQuotaHistory model, IMapper mapper)
        {
            mapper.Map<BaseSalesPersonQuotaHistory, CreateSalesPersonQuotaHistoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesPersonQuotaHistoryCommand, SalesPersonQuotaHistoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesPersonQuotaHistoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesPersonQuotaHistoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesPersonQuotaHistoryLookupModel> Handle(CreateSalesPersonQuotaHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesPersonQuotaHistoryCommand, Entities.SalesPersonQuotaHistory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesPersonQuotaHistories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesPersonQuotaHistories.FindAsync(new object[] { entity.SalesPersonID, entity.QuotaDate }, cancellationToken);

                await _mediator.Publish(new SalesPersonQuotaHistoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesPersonQuotaHistory, SalesPersonQuotaHistoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesPersonQuotaHistory, CreateSalesPersonQuotaHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesPersonQuotaHistoryCommand, Entities.SalesPersonQuotaHistory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
