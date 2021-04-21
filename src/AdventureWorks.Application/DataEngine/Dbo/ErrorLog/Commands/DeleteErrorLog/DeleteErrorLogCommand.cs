using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.DeleteErrorLog
{
    public partial class DeleteErrorLogCommand : IRequest
    {
        public int ErrorLogID { get; set; }
    }
}