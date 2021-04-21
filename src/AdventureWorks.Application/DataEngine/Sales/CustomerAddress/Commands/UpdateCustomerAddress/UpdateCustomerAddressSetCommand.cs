using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.UpdateCustomerAddress
{
    public partial class UpdateCustomerAddressSetCommand : IRequest<List<CustomerAddressLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCustomerAddressCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCustomerAddress>, List<UpdateCustomerAddressCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCustomerAddressCommand>, List<Entities.CustomerAddress>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.CustomerAddress>, List<Entities.CustomerAddress>>(MemberList.None);
        }
    }
}