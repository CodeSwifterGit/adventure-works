using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrationDetail
{
    public partial class GetIllustrationDetailQuery : IRequest<IllustrationLookupModel>
    {
        public int IllustrationID { get; set; }
    }
}
