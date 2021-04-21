using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultureDetail
{
    public partial class GetCultureDetailQuery : IRequest<CultureLookupModel>
    {
        public string CultureID { get; set; }
    }
}
