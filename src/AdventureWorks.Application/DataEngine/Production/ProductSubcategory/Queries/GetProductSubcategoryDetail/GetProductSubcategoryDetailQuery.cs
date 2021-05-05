using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategoryDetail
{
    public partial class GetProductSubcategoryDetailQuery : IRequest<ProductSubcategoryLookupModel>
    {
        public int ProductSubcategoryID { get; set; }
    }
}
