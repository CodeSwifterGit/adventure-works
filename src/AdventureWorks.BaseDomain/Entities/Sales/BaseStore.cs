using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseStore : IBaseEntity
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public int? SalesPersonID { get; set; }

        public string Demographics { get; set; }

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}