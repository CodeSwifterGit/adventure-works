using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.DeleteProductProductPhoto
{
    public partial class DeleteProductProductPhotoCommand : IRequest
    {
        public int ProductID { get; set; }
        public int ProductPhotoID { get; set; }
    }
}