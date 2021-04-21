using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Dbo
{
    public partial class BaseErrorLog : IBaseEntity
    {
        public int ErrorLogID { get; set; }

        public DateTime ErrorTime { get; set; }

        public string UserName { get; set; }

        public int ErrorNumber { get; set; }

        public int? ErrorSeverity { get; set; }

        public int? ErrorState { get; set; }

        public string ErrorProcedure { get; set; }

        public int? ErrorLine { get; set; }

        public string ErrorMessage { get; set; }
    }
}