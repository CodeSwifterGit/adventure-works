using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.UpdateWorkOrder;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager
{
    public partial class WorkOrdersQueryManager : DynamicQueryManager<Entities.WorkOrder, WorkOrderLookupModel, WorkOrderSummary, UpdateWorkOrderCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<WorkOrdersQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public WorkOrdersQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<WorkOrdersQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<WorkOrderLookupModel>> RequestData(
            IQueryable<Entities.WorkOrder> query,
            DataTableInfo<WorkOrderSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new WorkOrderSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}