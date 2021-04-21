using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddressDetail
{
    public partial class GetCustomerAddressDetailQuery : IRequest<CustomerAddressLookupModel>
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
    }
}
