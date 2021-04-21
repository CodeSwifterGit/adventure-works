using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.DeleteProductModelProductDescriptionCulture
{
    public partial class DeleteProductModelProductDescriptionCultureSetCommand : IRequest
    {
        public List<DeleteProductModelProductDescriptionCultureCommand> Commands { get; set; }
    }
}