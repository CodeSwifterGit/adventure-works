using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.UpdateSalesTerritory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.QueryManager
{
    public partial class SalesTerritoriesQueryManager : DynamicQueryManager<Entities.SalesTerritory, SalesTerritoryLookupModel, SalesTerritorySummary, UpdateSalesTerritoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<SalesTerritoriesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public SalesTerritoriesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<SalesTerritoriesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<SalesTerritoryLookupModel>> RequestData(
            IQueryable<Entities.SalesTerritory> query,
            DataTableInfo<SalesTerritorySummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new SalesTerritorySummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}