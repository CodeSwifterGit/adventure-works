using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.DeleteContactCreditCard
{
    public partial class DeleteContactCreditCardCommand : IRequest
    {
        public int ContactID { get; set; }
        public int CreditCardID { get; set; }
    }
}