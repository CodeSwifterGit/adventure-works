using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.UpdateSalesOrderHeaderSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager
{
    public partial class SalesOrderHeaderSalesReasonsQueryManager : DynamicQueryManager<Entities.SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonLookupModel, SalesOrderHeaderSalesReasonSummary, UpdateSalesOrderHeaderSalesReasonCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<SalesOrderHeaderSalesReasonsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public SalesOrderHeaderSalesReasonsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<SalesOrderHeaderSalesReasonsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<SalesOrderHeaderSalesReasonLookupModel>> RequestData(
            IQueryable<Entities.SalesOrderHeaderSalesReason> query,
            DataTableInfo<SalesOrderHeaderSalesReasonSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new SalesOrderHeaderSalesReasonSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}