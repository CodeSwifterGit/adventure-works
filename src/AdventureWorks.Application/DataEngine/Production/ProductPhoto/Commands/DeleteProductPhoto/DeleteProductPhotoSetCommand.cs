using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.DeleteProductPhoto
{
    public partial class DeleteProductPhotoSetCommand : IRequest
    {
        public List<DeleteProductPhotoCommand> Commands { get; set; }
    }
}