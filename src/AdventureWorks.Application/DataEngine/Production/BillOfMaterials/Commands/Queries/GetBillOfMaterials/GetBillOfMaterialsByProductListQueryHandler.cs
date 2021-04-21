using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials
{
    public partial class GetBillOfMaterialsByProductListQueryHandler : IRequestHandler<GetBillOfMaterialsByProductListQuery, BillOfMaterialsListViewModel>
    {
        private readonly BillOfMaterialsQueryManager _queryManager;

        public GetBillOfMaterialsByProductListQueryHandler(BillOfMaterialsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<BillOfMaterialsListViewModel> Handle(GetBillOfMaterialsByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductAssemblyID == request.ProductAssemblyID && x.ComponentID == request.ComponentID);

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
