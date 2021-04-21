using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseCurrencyRate : IBaseEntity
    {
        public int CurrencyRateID { get; set; }

        public DateTime CurrencyRateDate { get; set; }

        public string FromCurrencyCode { get; set; }

        public string ToCurrencyCode { get; set; }

        public decimal AverageRate { get; set; }

        public decimal EndOfDayRate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}