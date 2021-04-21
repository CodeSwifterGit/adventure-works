using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasonDetail
{
    public partial class GetScrapReasonDetailQuery : IRequest<ScrapReasonLookupModel>
    {
        public short ScrapReasonID { get; set; }
    }
}
