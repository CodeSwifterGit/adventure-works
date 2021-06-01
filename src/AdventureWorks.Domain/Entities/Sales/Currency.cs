using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Sales;


namespace AdventureWorks.Domain.Entities.Sales
{
    public partial class Currency : BaseCurrency, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; } = new List<CountryRegionCurrency>();

        public ICollection<CurrencyRate> CurrencyRatesFrom { get; set; } = new List<CurrencyRate>();
        public ICollection<CurrencyRate> CurrencyRatesTo { get; set; } = new List<CurrencyRate>();

        #endregion
    }
}