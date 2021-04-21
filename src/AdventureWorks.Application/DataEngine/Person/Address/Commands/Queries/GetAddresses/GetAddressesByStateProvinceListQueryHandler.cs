using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses
{
    public partial class GetAddressesByStateProvinceListQueryHandler : IRequestHandler<GetAddressesByStateProvinceListQuery, AddressesListViewModel>
    {
        private readonly AddressesQueryManager _queryManager;

        public GetAddressesByStateProvinceListQueryHandler(AddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<AddressesListViewModel> Handle(GetAddressesByStateProvinceListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.StateProvinceID == request.StateProvinceID);

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
