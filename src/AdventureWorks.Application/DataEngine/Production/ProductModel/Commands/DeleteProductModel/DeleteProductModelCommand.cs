using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.DeleteProductModel
{
    public partial class DeleteProductModelCommand : IRequest
    {
        public int ProductModelID { get; set; }
    }
}