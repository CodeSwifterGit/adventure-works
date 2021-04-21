using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.BaseDomain.Interfaces
{
    public interface ILoggingAt
    {
        [Column(TypeName = "datetime2")]
        DateTime ModifiedAt { get; set; }
    }
}