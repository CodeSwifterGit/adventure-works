using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.UpdateProductListPriceHistory;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager
{
    public partial class ProductListPriceHistoriesQueryManager : DynamicQueryManager<Entities.ProductListPriceHistory, ProductListPriceHistoryLookupModel, ProductListPriceHistorySummary, UpdateProductListPriceHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ProductListPriceHistoriesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public ProductListPriceHistoriesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ProductListPriceHistoriesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<ProductListPriceHistoryLookupModel>> RequestData(
            IQueryable<Entities.ProductListPriceHistory> query,
            DataTableInfo<ProductListPriceHistorySummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ProductListPriceHistorySummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}