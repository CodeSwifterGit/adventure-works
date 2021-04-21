using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProductDetail
{
    public partial class GetProductDetailQuery : IRequest<ProductLookupModel>
    {
        public int ProductID { get; set; }
    }
}
