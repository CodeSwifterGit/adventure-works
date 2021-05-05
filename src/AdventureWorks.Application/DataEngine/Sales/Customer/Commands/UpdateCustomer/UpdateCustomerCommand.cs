using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.UpdateCustomer
{
    public partial class UpdateCustomerCommand : IRequest<CustomerLookupModel>, IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public int? TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerType { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCustomerRequestTarget RequestTarget { get; set; }

        public UpdateCustomerCommand()
        {
        }

        public UpdateCustomerCommand(int customerID, BaseCustomer model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCustomerRequestTarget(customerID);
        }

        public UpdateCustomerCommand(int customerID)
        {
            CustomerID = customerID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCustomer, UpdateCustomerCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCustomerCommand, Entities.Customer>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Customer, Entities.Customer>(MemberList.None);
        }

        public partial class UpdateCustomerRequestTarget
        {
            public int CustomerID { get; set; }

            public UpdateCustomerRequestTarget()
            {
            }

            public UpdateCustomerRequestTarget(int customerID)
            {
                CustomerID = customerID;
            }
        }
    }
}