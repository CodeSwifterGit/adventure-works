using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOfferDetail
{
    public partial class GetSpecialOfferDetailQuery : IRequest<SpecialOfferLookupModel>
    {
        public int SpecialOfferID { get; set; }
    }
}
