using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModelDetail
{
    public partial class GetProductModelDetailQuery : IRequest<ProductModelLookupModel>
    {
        public int ProductModelID { get; set; }
    }
}
