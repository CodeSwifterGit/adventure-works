using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.DeleteSpecialOfferProduct
{
    public partial class DeleteSpecialOfferProductCommand : IRequest
    {
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
    }
}