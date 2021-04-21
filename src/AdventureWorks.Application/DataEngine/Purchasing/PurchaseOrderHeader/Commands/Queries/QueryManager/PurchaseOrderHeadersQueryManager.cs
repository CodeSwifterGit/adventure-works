using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.UpdatePurchaseOrderHeader;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.QueryManager
{
    public partial class PurchaseOrderHeadersQueryManager : DynamicQueryManager<Entities.PurchaseOrderHeader, PurchaseOrderHeaderLookupModel, PurchaseOrderHeaderSummary, UpdatePurchaseOrderHeaderCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<PurchaseOrderHeadersQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public PurchaseOrderHeadersQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<PurchaseOrderHeadersQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<PurchaseOrderHeaderLookupModel>> RequestData(
            IQueryable<Entities.PurchaseOrderHeader> query,
            DataTableInfo<PurchaseOrderHeaderSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new PurchaseOrderHeaderSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}