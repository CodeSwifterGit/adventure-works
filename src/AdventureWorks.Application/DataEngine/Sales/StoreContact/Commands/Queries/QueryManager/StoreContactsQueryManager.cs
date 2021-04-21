using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.UpdateStoreContact;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager
{
    public partial class StoreContactsQueryManager : DynamicQueryManager<Entities.StoreContact, StoreContactLookupModel, StoreContactSummary, UpdateStoreContactCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<StoreContactsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public StoreContactsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<StoreContactsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<StoreContactLookupModel>> RequestData(
            IQueryable<Entities.StoreContact> query,
            DataTableInfo<StoreContactSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new StoreContactSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}