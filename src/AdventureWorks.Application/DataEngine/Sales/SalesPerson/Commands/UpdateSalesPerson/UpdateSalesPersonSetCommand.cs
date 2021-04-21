using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.UpdateSalesPerson
{
    public partial class UpdateSalesPersonSetCommand : IRequest<List<SalesPersonLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesPersonCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesPerson>, List<UpdateSalesPersonCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesPersonCommand>, List<Entities.SalesPerson>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesPerson>, List<Entities.SalesPerson>>(MemberList.None);
        }
    }
}