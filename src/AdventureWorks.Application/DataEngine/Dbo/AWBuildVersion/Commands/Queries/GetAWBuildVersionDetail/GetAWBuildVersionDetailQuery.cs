using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersionDetail
{
    public partial class GetAWBuildVersionDetailQuery : IRequest<AWBuildVersionLookupModel>
    {
        public byte SystemInformationID { get; set; }
    }
}
