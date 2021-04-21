using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.DeleteProductSubcategory
{
    public partial class DeleteProductSubcategorySetCommand : IRequest
    {
        public List<DeleteProductSubcategoryCommand> Commands { get; set; }
    }
}