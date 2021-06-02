using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;


namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs
{
    public partial class DatabaseLogLookupModel : IHaveCustomMapping
    {
        public int DatabaseLogID { get; set; }
        public DateTime PostTime { get; set; }
        public string DatabaseUser { get; set; }
        public string Event { get; set; }
        public string Schema { get; set; }
        public string Object { get; set; }
        public string Tsql { get; set; }
        public string XmlEvent { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Dbo.DatabaseLog, DatabaseLogLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<DatabaseLogLookupModel, BaseDatabaseLog>().IgnoreMissingDestinationMembers();
        }
    }
}
