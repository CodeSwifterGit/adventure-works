using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.DeleteProductModelProductDescriptionCulture
{
    public partial class DeleteProductModelProductDescriptionCultureCommand : IRequest
    {
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string CultureID { get; set; }
    }
}