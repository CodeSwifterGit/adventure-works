using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogDetail
{
    public partial class GetDatabaseLogDetailQuery : IRequest<DatabaseLogLookupModel>
    {
        public int DatabaseLogID { get; set; }
    }
}
