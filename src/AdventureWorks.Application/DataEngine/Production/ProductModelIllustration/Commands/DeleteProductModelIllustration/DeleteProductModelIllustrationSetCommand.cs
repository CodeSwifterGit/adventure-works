using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.DeleteProductModelIllustration
{
    public partial class DeleteProductModelIllustrationSetCommand : IRequest
    {
        public List<DeleteProductModelIllustrationCommand> Commands { get; set; }
    }
}