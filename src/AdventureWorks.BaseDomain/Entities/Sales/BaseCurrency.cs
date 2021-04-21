using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseCurrency : IBaseEntity
    {
        public string CurrencyCode { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}