using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategoryDetail
{
    public partial class GetProductCategoryDetailQuery : IRequest<ProductCategoryLookupModel>
    {
        public int ProductCategoryID { get; set; }
    }
}
