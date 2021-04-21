using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.UpdateDatabaseLog
{
    public partial class UpdateDatabaseLogSetCommand : IRequest<List<DatabaseLogLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateDatabaseLogCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseDatabaseLog>, List<UpdateDatabaseLogCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateDatabaseLogCommand>, List<Entities.DatabaseLog>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.DatabaseLog>, List<Entities.DatabaseLog>>(MemberList.None);
        }
    }
}