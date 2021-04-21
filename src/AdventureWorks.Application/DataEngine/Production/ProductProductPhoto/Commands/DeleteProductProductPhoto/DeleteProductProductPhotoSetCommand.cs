using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.DeleteProductProductPhoto
{
    public partial class DeleteProductProductPhotoSetCommand : IRequest
    {
        public List<DeleteProductProductPhotoCommand> Commands { get; set; }
    }
}