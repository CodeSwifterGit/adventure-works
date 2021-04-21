using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.UpdateCountryRegionCurrency;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager
{
    public partial class CountryRegionCurrenciesQueryManager : DynamicQueryManager<Entities.CountryRegionCurrency, CountryRegionCurrencyLookupModel, CountryRegionCurrencySummary, UpdateCountryRegionCurrencyCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<CountryRegionCurrenciesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public CountryRegionCurrenciesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<CountryRegionCurrenciesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<CountryRegionCurrencyLookupModel>> RequestData(
            IQueryable<Entities.CountryRegionCurrency> query,
            DataTableInfo<CountryRegionCurrencySummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new CountryRegionCurrencySummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}