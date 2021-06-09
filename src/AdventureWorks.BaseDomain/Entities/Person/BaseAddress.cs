using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Person
{
    public partial class BaseAddress : IBaseEntity
    {
        public int AddressID { get; set; }

        public string AddressLine1 { get; set; } = "";

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public int StateProvinceID { get; set; }

        public string PostalCode { get; set; }

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}