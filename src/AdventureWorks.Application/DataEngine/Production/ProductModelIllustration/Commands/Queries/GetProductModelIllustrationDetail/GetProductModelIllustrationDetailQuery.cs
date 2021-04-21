using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrationDetail
{
    public partial class GetProductModelIllustrationDetailQuery : IRequest<ProductModelIllustrationLookupModel>
    {
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }
    }
}
