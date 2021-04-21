using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.UpdateSalesOrderHeaderSalesReason
{
    public partial class UpdateSalesOrderHeaderSalesReasonSetCommand : IRequest<List<SalesOrderHeaderSalesReasonLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesOrderHeaderSalesReasonCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesOrderHeaderSalesReason>, List<UpdateSalesOrderHeaderSalesReasonCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesOrderHeaderSalesReasonCommand>, List<Entities.SalesOrderHeaderSalesReason>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesOrderHeaderSalesReason>, List<Entities.SalesOrderHeaderSalesReason>>(MemberList.None);
        }
    }
}