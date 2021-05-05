using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes
{
    public partial class GetAddressTypesListQueryHandler : IRequestHandler<GetAddressTypesListQuery, AddressTypesListViewModel>
    {
        private readonly AddressTypesQueryManager _queryManager;

        public GetAddressTypesListQueryHandler(AddressTypesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<AddressTypesListViewModel> Handle(GetAddressTypesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new AddressTypesListViewModel
            {
                AddressTypes = listResult,
                DataTable = DataTableResponseInfo<AddressTypeSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
