using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.DeleteProductPhoto
{
    public partial class DeleteProductPhotoCommand : IRequest
    {
        public int ProductPhotoID { get; set; }
    }
}