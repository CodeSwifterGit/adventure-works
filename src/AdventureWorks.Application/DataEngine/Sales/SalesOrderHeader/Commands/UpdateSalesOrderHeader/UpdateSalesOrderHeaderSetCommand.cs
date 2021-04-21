using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.UpdateSalesOrderHeader
{
    public partial class UpdateSalesOrderHeaderSetCommand : IRequest<List<SalesOrderHeaderLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesOrderHeaderCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesOrderHeader>, List<UpdateSalesOrderHeaderCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesOrderHeaderCommand>, List<Entities.SalesOrderHeader>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesOrderHeader>, List<Entities.SalesOrderHeader>>(MemberList.None);
        }
    }
}