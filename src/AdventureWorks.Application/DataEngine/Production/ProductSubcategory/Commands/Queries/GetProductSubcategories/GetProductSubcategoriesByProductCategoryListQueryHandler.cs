using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories
{
    public partial class GetProductSubcategoriesByProductCategoryListQueryHandler : IRequestHandler<GetProductSubcategoriesByProductCategoryListQuery, ProductSubcategoriesListViewModel>
    {
        private readonly ProductSubcategoriesQueryManager _queryManager;

        public GetProductSubcategoriesByProductCategoryListQueryHandler(ProductSubcategoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductSubcategoriesListViewModel> Handle(GetProductSubcategoriesByProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductCategoryID == request.ProductCategoryID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductSubcategoriesListViewModel
            {
                ProductSubcategories = listResult,
                DataTable = DataTableResponseInfo<ProductSubcategorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
