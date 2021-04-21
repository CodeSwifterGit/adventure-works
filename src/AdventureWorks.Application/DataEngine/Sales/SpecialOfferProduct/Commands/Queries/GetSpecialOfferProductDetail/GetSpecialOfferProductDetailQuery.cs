using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProductDetail
{
    public partial class GetSpecialOfferProductDetailQuery : IRequest<SpecialOfferProductLookupModel>
    {
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
    }
}
