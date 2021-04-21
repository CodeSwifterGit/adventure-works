using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses
{
    public partial class GetAddressesListQueryHandler : IRequestHandler<GetAddressesListQuery, AddressesListViewModel>
    {
        private readonly AddressesQueryManager _queryManager;

        public GetAddressesListQueryHandler(AddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<AddressesListViewModel> Handle(GetAddressesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new AddressesListViewModel
            {
                Addresses = listResult,
                DataTable = DataTableResponseInfo<AddressSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
