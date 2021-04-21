using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.DeleteCreditCard
{
    public partial class DeleteCreditCardCommand : IRequest
    {
        public int CreditCardID { get; set; }
    }
}