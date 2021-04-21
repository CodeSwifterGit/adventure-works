using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.UpdateSalesOrderHeaderSalesReason
{
    public partial class UpdateSalesOrderHeaderSalesReasonCommand : BaseSalesOrderHeaderSalesReason, IRequest<SalesOrderHeaderSalesReasonLookupModel>, IHaveCustomMapping
    {
        public int SalesOrderID { get; set; }
        public int SalesReasonID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesOrderHeaderSalesReasonRequestTarget RequestTarget { get; set; }

        public UpdateSalesOrderHeaderSalesReasonCommand()
        {
        }

        public UpdateSalesOrderHeaderSalesReasonCommand(int salesOrderID, int salesReasonID, BaseSalesOrderHeaderSalesReason model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesOrderHeaderSalesReasonRequestTarget(salesOrderID, salesReasonID);
        }

        public UpdateSalesOrderHeaderSalesReasonCommand(int salesOrderID, int salesReasonID)
        {
            SalesOrderID = salesOrderID;
            SalesReasonID = salesReasonID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesOrderHeaderSalesReason, UpdateSalesOrderHeaderSalesReasonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesOrderHeaderSalesReasonCommand, Entities.SalesOrderHeaderSalesReason>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesOrderHeaderSalesReason, Entities.SalesOrderHeaderSalesReason>(MemberList.None);
        }

        public partial class UpdateSalesOrderHeaderSalesReasonRequestTarget
        {
            public int SalesOrderID { get; set; }
            public int SalesReasonID { get; set; }

            public UpdateSalesOrderHeaderSalesReasonRequestTarget()
            {
            }

            public UpdateSalesOrderHeaderSalesReasonRequestTarget(int salesOrderID, int salesReasonID)
            {
                SalesOrderID = salesOrderID;
                SalesReasonID = salesReasonID;
            }
        }
    }
}