using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals
{
    public partial class GetIndividualsListQueryHandler : IRequestHandler<GetIndividualsListQuery, IndividualsListViewModel>
    {
        private readonly IndividualsQueryManager _queryManager;

        public GetIndividualsListQueryHandler(IndividualsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<IndividualsListViewModel> Handle(GetIndividualsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
