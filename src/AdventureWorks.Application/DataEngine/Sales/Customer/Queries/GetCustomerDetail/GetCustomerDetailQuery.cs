using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomerDetail
{
    public partial class GetCustomerDetailQuery : IRequest<CustomerLookupModel>
    {
        public int CustomerID { get; set; }
    }
}
