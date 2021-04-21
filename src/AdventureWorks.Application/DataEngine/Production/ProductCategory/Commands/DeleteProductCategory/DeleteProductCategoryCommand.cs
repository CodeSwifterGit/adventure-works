using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.DeleteProductCategory
{
    public partial class DeleteProductCategoryCommand : IRequest
    {
        public int ProductCategoryID { get; set; }
    }
}