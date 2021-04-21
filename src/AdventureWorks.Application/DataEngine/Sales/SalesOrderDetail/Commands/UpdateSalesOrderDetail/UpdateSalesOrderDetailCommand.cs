using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.UpdateSalesOrderDetail
{
    public partial class UpdateSalesOrderDetailCommand : BaseSalesOrderDetail, IRequest<SalesOrderDetailLookupModel>, IHaveCustomMapping
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesOrderDetailRequestTarget RequestTarget { get; set; }

        public UpdateSalesOrderDetailCommand()
        {
        }

        public UpdateSalesOrderDetailCommand(int salesOrderID, int salesOrderDetailID, BaseSalesOrderDetail model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesOrderDetailRequestTarget(salesOrderID, salesOrderDetailID);
        }

        public UpdateSalesOrderDetailCommand(int salesOrderID, int salesOrderDetailID)
        {
            SalesOrderID = salesOrderID;
            SalesOrderDetailID = salesOrderDetailID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesOrderDetail, UpdateSalesOrderDetailCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesOrderDetailCommand, Entities.SalesOrderDetail>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesOrderDetail, Entities.SalesOrderDetail>(MemberList.None);
        }

        public partial class UpdateSalesOrderDetailRequestTarget
        {
            public int SalesOrderID { get; set; }
            public int SalesOrderDetailID { get; set; }

            public UpdateSalesOrderDetailRequestTarget()
            {
            }

            public UpdateSalesOrderDetailRequestTarget(int salesOrderID, int salesOrderDetailID)
            {
                SalesOrderID = salesOrderID;
                SalesOrderDetailID = salesOrderDetailID;
            }
        }
    }
}