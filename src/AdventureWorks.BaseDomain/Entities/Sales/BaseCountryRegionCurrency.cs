using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseCountryRegionCurrency : IBaseEntity
    {
        public string CountryRegionCode { get; set; }

        public string CurrencyCode { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}