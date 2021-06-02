using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses
{
    public partial class CustomerAddressLookupModel : IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
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
            configuration.CreateMap<Domain.Entities.Sales.CustomerAddress, CustomerAddressLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<CustomerAddressLookupModel, BaseCustomerAddress>().IgnoreMissingDestinationMembers();
        }
    }
}
