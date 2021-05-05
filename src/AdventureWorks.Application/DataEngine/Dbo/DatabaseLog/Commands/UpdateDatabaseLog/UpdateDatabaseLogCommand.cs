using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.UpdateDatabaseLog
{
    public partial class UpdateDatabaseLogCommand : IRequest<DatabaseLogLookupModel>, IHaveCustomMapping
    {
        public int DatabaseLogID { get; set; }
        public DateTime PostTime { get; set; }
        public string DatabaseUser { get; set; }
        public string Event { get; set; }
        public string Schema { get; set; }
        public string Object { get; set; }
        public string Tsql { get; set; }
        public string XmlEvent { get; set; }

        public UpdateDatabaseLogRequestTarget RequestTarget { get; set; }

        public UpdateDatabaseLogCommand()
        {
        }

        public UpdateDatabaseLogCommand(int databaseLogID, BaseDatabaseLog model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateDatabaseLogRequestTarget(databaseLogID);
        }

        public UpdateDatabaseLogCommand(int databaseLogID)
        {
            DatabaseLogID = databaseLogID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseDatabaseLog, UpdateDatabaseLogCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateDatabaseLogCommand, Entities.DatabaseLog>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.DatabaseLog, Entities.DatabaseLog>(MemberList.None);
        }

        public partial class UpdateDatabaseLogRequestTarget
        {
            public int DatabaseLogID { get; set; }

            public UpdateDatabaseLogRequestTarget()
            {
            }

            public UpdateDatabaseLogRequestTarget(int databaseLogID)
            {
                DatabaseLogID = databaseLogID;
            }
        }
    }
}