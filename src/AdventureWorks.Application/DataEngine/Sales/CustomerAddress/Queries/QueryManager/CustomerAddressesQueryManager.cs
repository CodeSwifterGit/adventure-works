using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.UpdateCustomerAddress;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using AdventureWorks.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager
{
    public partial class CustomerAddressesQueryManager : DynamicQueryManager<Entities.CustomerAddress, CustomerAddressLookupModel, CustomerAddressSummary, UpdateCustomerAddressCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<CustomerAddressesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;
        private readonly IDateTime _machineDateTime;
        private readonly INotificationService _notificationService;

        public CustomerAddressesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<CustomerAddressesQueryManager> logger, INotificationService notificationService, IDateTime machineDateTime) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
            _machineDateTime = machineDateTime;
            _notificationService = notificationService;
        }

        public override async Task<List<CustomerAddressLookupModel>> RequestData(
            IQueryable<Entities.CustomerAddress> query,
            DataTableInfo<CustomerAddressSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new CustomerAddressSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}