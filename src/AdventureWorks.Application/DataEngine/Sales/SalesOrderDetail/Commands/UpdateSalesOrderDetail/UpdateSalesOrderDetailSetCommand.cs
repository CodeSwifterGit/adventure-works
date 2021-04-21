using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.UpdateSalesOrderDetail
{
    public partial class UpdateSalesOrderDetailSetCommand : IRequest<List<SalesOrderDetailLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesOrderDetailCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesOrderDetail>, List<UpdateSalesOrderDetailCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesOrderDetailCommand>, List<Entities.SalesOrderDetail>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesOrderDetail>, List<Entities.SalesOrderDetail>>(MemberList.None);
        }
    }
}