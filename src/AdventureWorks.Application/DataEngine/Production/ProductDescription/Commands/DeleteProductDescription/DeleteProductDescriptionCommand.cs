using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.DeleteProductDescription
{
    public partial class DeleteProductDescriptionCommand : IRequest
    {
        public int ProductDescriptionID { get; set; }
    }
}