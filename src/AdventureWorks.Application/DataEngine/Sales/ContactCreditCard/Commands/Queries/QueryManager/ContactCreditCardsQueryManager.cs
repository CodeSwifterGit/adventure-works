using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.UpdateContactCreditCard;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager
{
    public partial class ContactCreditCardsQueryManager : DynamicQueryManager<Entities.ContactCreditCard, ContactCreditCardLookupModel, ContactCreditCardSummary, UpdateContactCreditCardCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ContactCreditCardsQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;

        public ContactCreditCardsQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ContactCreditCardsQueryManager> logger) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public override async Task<List<ContactCreditCardLookupModel>> RequestData(
            IQueryable<Entities.ContactCreditCard> query,
            DataTableInfo<ContactCreditCardSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ContactCreditCardSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}