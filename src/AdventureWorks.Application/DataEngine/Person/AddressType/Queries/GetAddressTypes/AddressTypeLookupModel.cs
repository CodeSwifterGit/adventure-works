using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes
{
    public partial class AddressTypeLookupModel : IHaveCustomMapping
    {
        public int AddressTypeID { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Person.AddressType, AddressTypeLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<AddressTypeLookupModel, BaseAddressType>().IgnoreMissingDestinationMembers();
        }
    }
}
