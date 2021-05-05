using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials
{
    public partial class GetBillOfMaterialsListQueryHandler : IRequestHandler<GetBillOfMaterialsListQuery, BillOfMaterialsListViewModel>
    {
        private readonly BillOfMaterialsQueryManager _queryManager;

        public GetBillOfMaterialsListQueryHandler(BillOfMaterialsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<BillOfMaterialsListViewModel> Handle(GetBillOfMaterialsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new BillOfMaterialsListViewModel
            {
                BillOfMaterials = listResult,
                DataTable = DataTableResponseInfo<BillOfMaterialsSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
