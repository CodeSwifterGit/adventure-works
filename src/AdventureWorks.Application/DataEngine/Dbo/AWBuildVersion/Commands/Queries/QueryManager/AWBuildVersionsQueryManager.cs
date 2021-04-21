using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.UpdateAWBuildVersion;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager
{
    public partial class AWBuildVersionsQueryManager : DynamicQueryManager<Entities.AWBuildVersion, AWBuildVersionLookupModel, AWBuildVersionSummary, UpdateAWBuildVersionCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<AWBuildVersionsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public AWBuildVersionsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<AWBuildVersionsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<AWBuildVersionLookupModel>> RequestData(
            IQueryable<Entities.AWBuildVersion> query,
            DataTableInfo<AWBuildVersionSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new AWBuildVersionSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}