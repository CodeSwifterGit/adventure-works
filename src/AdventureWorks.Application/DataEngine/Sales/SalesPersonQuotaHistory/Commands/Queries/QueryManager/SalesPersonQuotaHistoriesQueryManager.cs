using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.UpdateSalesPersonQuotaHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager
{
    public partial class SalesPersonQuotaHistoriesQueryManager : DynamicQueryManager<Entities.SalesPersonQuotaHistory, SalesPersonQuotaHistoryLookupModel, SalesPersonQuotaHistorySummary, UpdateSalesPersonQuotaHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<SalesPersonQuotaHistoriesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public SalesPersonQuotaHistoriesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<SalesPersonQuotaHistoriesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<SalesPersonQuotaHistoryLookupModel>> RequestData(
            IQueryable<Entities.SalesPersonQuotaHistory> query,
            DataTableInfo<SalesPersonQuotaHistorySummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new SalesPersonQuotaHistorySummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}