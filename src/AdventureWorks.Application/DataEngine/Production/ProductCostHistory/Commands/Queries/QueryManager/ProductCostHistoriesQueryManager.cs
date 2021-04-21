using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.UpdateProductCostHistory;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager
{
    public partial class ProductCostHistoriesQueryManager : DynamicQueryManager<Entities.ProductCostHistory, ProductCostHistoryLookupModel, ProductCostHistorySummary, UpdateProductCostHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ProductCostHistoriesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public ProductCostHistoriesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ProductCostHistoriesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<ProductCostHistoryLookupModel>> RequestData(
            IQueryable<Entities.ProductCostHistory> query,
            DataTableInfo<ProductCostHistorySummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ProductCostHistorySummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}