using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.UpdateProductModelProductDescriptionCulture;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager
{
    public partial class ProductModelProductDescriptionCulturesQueryManager : DynamicQueryManager<Entities.ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureLookupModel, ProductModelProductDescriptionCultureSummary, UpdateProductModelProductDescriptionCultureCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ProductModelProductDescriptionCulturesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public ProductModelProductDescriptionCulturesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ProductModelProductDescriptionCulturesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<ProductModelProductDescriptionCultureLookupModel>> RequestData(
            IQueryable<Entities.ProductModelProductDescriptionCulture> query,
            DataTableInfo<ProductModelProductDescriptionCultureSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ProductModelProductDescriptionCultureSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}