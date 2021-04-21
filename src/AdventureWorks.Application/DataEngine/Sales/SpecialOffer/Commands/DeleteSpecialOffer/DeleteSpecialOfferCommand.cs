using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.DeleteSpecialOffer
{
    public partial class DeleteSpecialOfferCommand : IRequest
    {
        public int SpecialOfferID { get; set; }
    }
}