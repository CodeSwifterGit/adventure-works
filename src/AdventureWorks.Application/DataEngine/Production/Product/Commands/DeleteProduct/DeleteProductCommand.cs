using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.DeleteProduct
{
    public partial class DeleteProductCommand : IRequest
    {
        public int ProductID { get; set; }
    }
}