using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Dbo
{
    public partial class BaseDatabaseLog : IBaseEntity
    {
        public int DatabaseLogID { get; set; }

        public DateTime PostTime { get; set; }

        public string DatabaseUser { get; set; }

        public string Event { get; set; }

        public string Schema { get; set; }

        public string Object { get; set; }

        public string Tsql { get; set; }

        public string XmlEvent { get; set; }
    }
}