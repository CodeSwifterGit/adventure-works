using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.UpdateCustomer
{
    public partial class UpdateCustomerSetCommand : IRequest<List<CustomerLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCustomerCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCustomer>, List<UpdateCustomerCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCustomerCommand>, List<Entities.Customer>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Customer>, List<Entities.Customer>>(MemberList.None);
        }
    }
}