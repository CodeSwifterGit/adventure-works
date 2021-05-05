using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals
{
    public partial class GetIndividualsByCustomerListQueryHandler : IRequestHandler<GetIndividualsByCustomerListQuery, IndividualsListViewModel>
    {
        private readonly IndividualsQueryManager _queryManager;

        public GetIndividualsByCustomerListQueryHandler(IndividualsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<IndividualsListViewModel> Handle(GetIndividualsByCustomerListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.CustomerID == request.CustomerID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new IndividualsListViewModel
            {
                Individuals = listResult,
                DataTable = DataTableResponseInfo<IndividualSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
