using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.BaseDomain.Interfaces
{
    public interface ICreatingAt
    {
        [Column(TypeName = "datetime2")]
        DateTime CreatedAt { get; set; }
    }
}