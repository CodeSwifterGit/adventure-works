using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCardDetail
{
    public partial class GetContactCreditCardDetailQuery : IRequest<ContactCreditCardLookupModel>
    {
        public int ContactID { get; set; }
        public int CreditCardID { get; set; }
    }
}
