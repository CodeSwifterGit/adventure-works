using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCardDetail
{
    public partial class GetCreditCardDetailQuery : IRequest<CreditCardLookupModel>
    {
        public int CreditCardID { get; set; }
    }
}
