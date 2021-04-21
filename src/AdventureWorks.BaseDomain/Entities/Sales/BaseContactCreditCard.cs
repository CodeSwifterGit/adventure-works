using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseContactCreditCard : IBaseEntity
    {
        public int ContactID { get; set; }

        public int CreditCardID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}