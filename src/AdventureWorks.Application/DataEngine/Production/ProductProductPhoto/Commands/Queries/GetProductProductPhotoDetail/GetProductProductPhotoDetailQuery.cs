using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotoDetail
{
    public partial class GetProductProductPhotoDetailQuery : IRequest<ProductProductPhotoLookupModel>
    {
        public int ProductID { get; set; }
        public int ProductPhotoID { get; set; }
    }
}
