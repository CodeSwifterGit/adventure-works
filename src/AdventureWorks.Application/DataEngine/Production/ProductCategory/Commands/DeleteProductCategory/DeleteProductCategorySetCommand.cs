using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.DeleteProductCategory
{
    public partial class DeleteProductCategorySetCommand : IRequest
    {
        public List<DeleteProductCategoryCommand> Commands { get; set; }
    }
}