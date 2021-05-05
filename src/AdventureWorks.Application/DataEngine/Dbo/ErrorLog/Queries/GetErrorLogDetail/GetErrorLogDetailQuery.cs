using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogDetail
{
    public partial class GetErrorLogDetailQuery : IRequest<ErrorLogLookupModel>
    {
        public int ErrorLogID { get; set; }
    }
}
