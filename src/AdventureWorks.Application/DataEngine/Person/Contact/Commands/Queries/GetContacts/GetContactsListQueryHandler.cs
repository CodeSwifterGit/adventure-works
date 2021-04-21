using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts
{
    public partial class GetContactsListQueryHandler : IRequestHandler<GetContactsListQuery, ContactsListViewModel>
    {
        private readonly ContactsQueryManager _queryManager;

        public GetContactsListQueryHandler(ContactsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ContactsListViewModel> Handle(GetContactsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ContactsListViewModel
            {
                Contacts = listResult,
                DataTable = DataTableResponseInfo<ContactSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
