using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.UpdateEmployeeAddress;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager
{
    public partial class EmployeeAddressesQueryManager : DynamicQueryManager<Entities.EmployeeAddress, EmployeeAddressLookupModel, EmployeeAddressSummary, UpdateEmployeeAddressCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<EmployeeAddressesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public EmployeeAddressesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<EmployeeAddressesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<EmployeeAddressLookupModel>> RequestData(
            IQueryable<Entities.EmployeeAddress> query,
            DataTableInfo<EmployeeAddressSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new EmployeeAddressSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}