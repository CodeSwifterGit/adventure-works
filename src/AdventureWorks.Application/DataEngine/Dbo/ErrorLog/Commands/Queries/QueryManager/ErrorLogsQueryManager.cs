using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.UpdateErrorLog;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager
{
    public partial class ErrorLogsQueryManager : DynamicQueryManager<Entities.ErrorLog, ErrorLogLookupModel, ErrorLogSummary, UpdateErrorLogCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ErrorLogsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public ErrorLogsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ErrorLogsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<ErrorLogLookupModel>> RequestData(
            IQueryable<Entities.ErrorLog> query,
            DataTableInfo<ErrorLogSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ErrorLogSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}