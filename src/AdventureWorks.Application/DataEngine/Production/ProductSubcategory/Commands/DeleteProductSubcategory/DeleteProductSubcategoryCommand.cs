using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.DeleteProductSubcategory
{
    public partial class DeleteProductSubcategoryCommand : IRequest
    {
        public int ProductSubcategoryID { get; set; }
    }
}