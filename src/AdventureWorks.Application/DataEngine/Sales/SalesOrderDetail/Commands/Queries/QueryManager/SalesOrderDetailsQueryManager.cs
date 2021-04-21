using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.UpdateSalesOrderDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager
{
    public partial class SalesOrderDetailsQueryManager : DynamicQueryManager<Entities.SalesOrderDetail, SalesOrderDetailLookupModel, SalesOrderDetailSummary, UpdateSalesOrderDetailCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<SalesOrderDetailsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public SalesOrderDetailsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<SalesOrderDetailsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<SalesOrderDetailLookupModel>> RequestData(
            IQueryable<Entities.SalesOrderDetail> query,
            DataTableInfo<SalesOrderDetailSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new SalesOrderDetailSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}