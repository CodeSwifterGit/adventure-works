using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.UpdateErrorLog
{
    public partial class UpdateErrorLogSetCommand : IRequest<List<ErrorLogLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateErrorLogCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseErrorLog>, List<UpdateErrorLogCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateErrorLogCommand>, List<Entities.ErrorLog>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ErrorLog>, List<Entities.ErrorLog>>(MemberList.None);
        }
    }
}