using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes
{
    public partial class GetContactTypesListQueryHandler : IRequestHandler<GetContactTypesListQuery, ContactTypesListViewModel>
    {
        private readonly ContactTypesQueryManager _queryManager;

        public GetContactTypesListQueryHandler(ContactTypesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ContactTypesListViewModel> Handle(GetContactTypesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ContactTypesListViewModel
            {
                ContactTypes = listResult,
                DataTable = DataTableResponseInfo<ContactTypeSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
