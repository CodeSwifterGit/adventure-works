using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.UpdateCustomerAddress
{
    public partial class UpdateCustomerAddressCommand : IRequest<CustomerAddressLookupModel>, IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCustomerAddressRequestTarget RequestTarget { get; set; }

        public UpdateCustomerAddressCommand()
        {
        }

        public UpdateCustomerAddressCommand(int customerID, int addressID, BaseCustomerAddress model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCustomerAddressRequestTarget(customerID, addressID);
        }

        public UpdateCustomerAddressCommand(int customerID, int addressID)
        {
            CustomerID = customerID;
            AddressID = addressID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCustomerAddress, UpdateCustomerAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCustomerAddressCommand, Entities.CustomerAddress>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.CustomerAddress, Entities.CustomerAddress>(MemberList.None);
        }

        public partial class UpdateCustomerAddressRequestTarget
        {
            public int CustomerID { get; set; }
            public int AddressID { get; set; }

            public UpdateCustomerAddressRequestTarget()
            {
            }

            public UpdateCustomerAddressRequestTarget(int customerID, int addressID)
            {
                CustomerID = customerID;
                AddressID = addressID;
            }
        }
    }
}