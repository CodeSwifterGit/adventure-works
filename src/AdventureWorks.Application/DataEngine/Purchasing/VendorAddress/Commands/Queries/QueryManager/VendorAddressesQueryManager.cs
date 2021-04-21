using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.UpdateVendorAddress;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager
{
    public partial class VendorAddressesQueryManager : DynamicQueryManager<Entities.VendorAddress, VendorAddressLookupModel, VendorAddressSummary, UpdateVendorAddressCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<VendorAddressesQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public VendorAddressesQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<VendorAddressesQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<VendorAddressLookupModel>> RequestData(
            IQueryable<Entities.VendorAddress> query,
            DataTableInfo<VendorAddressSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new VendorAddressSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}