using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptionDetail
{
    public partial class GetProductDescriptionDetailQuery : IRequest<ProductDescriptionLookupModel>
    {
        public int ProductDescriptionID { get; set; }
    }
}
