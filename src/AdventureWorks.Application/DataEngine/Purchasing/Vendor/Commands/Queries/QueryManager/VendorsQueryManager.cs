using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.UpdateVendor;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager
{
    public partial class VendorsQueryManager : DynamicQueryManager<Entities.Vendor, VendorLookupModel, VendorSummary, UpdateVendorCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<VendorsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public VendorsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<VendorsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<VendorLookupModel>> RequestData(
            IQueryable<Entities.Vendor> query,
            DataTableInfo<VendorSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new VendorSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}