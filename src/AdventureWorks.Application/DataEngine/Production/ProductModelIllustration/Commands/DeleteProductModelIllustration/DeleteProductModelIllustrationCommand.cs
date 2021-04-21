using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.DeleteProductModelIllustration
{
    public partial class DeleteProductModelIllustrationCommand : IRequest
    {
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }
    }
}