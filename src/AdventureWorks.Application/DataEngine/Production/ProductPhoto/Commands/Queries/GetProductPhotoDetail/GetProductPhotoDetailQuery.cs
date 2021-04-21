using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotoDetail
{
    public partial class GetProductPhotoDetailQuery : IRequest<ProductPhotoLookupModel>
    {
        public int ProductPhotoID { get; set; }
    }
}
