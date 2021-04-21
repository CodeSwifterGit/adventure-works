using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.UpdateProductInventory;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager
{
    public partial class ProductInventoriesQueryManager : DynamicQueryManager<Entities.ProductInventory, ProductInventoryLookupModel, ProductInventorySummary, UpdateProductInventoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ProductInventoriesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public ProductInventoriesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ProductInventoriesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<ProductInventoryLookupModel>> RequestData(
            IQueryable<Entities.ProductInventory> query,
            DataTableInfo<ProductInventorySummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ProductInventorySummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}