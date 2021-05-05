using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.UpdatePurchaseOrderDetail
{
    public partial class UpdatePurchaseOrderDetailCommand : IRequest<PurchaseOrderDetailLookupModel>, IHaveCustomMapping
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderDetailID { get; set; }
        public DateTime DueDate { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal RejectedQty { get; set; }
        public decimal StockedQty { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdatePurchaseOrderDetailRequestTarget RequestTarget { get; set; }

        public UpdatePurchaseOrderDetailCommand()
        {
        }

        public UpdatePurchaseOrderDetailCommand(int purchaseOrderID, int purchaseOrderDetailID, BasePurchaseOrderDetail model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdatePurchaseOrderDetailRequestTarget(purchaseOrderID, purchaseOrderDetailID);
        }

        public UpdatePurchaseOrderDetailCommand(int purchaseOrderID, int purchaseOrderDetailID)
        {
            PurchaseOrderID = purchaseOrderID;
            PurchaseOrderDetailID = purchaseOrderDetailID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BasePurchaseOrderDetail, UpdatePurchaseOrderDetailCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdatePurchaseOrderDetailCommand, Entities.PurchaseOrderDetail>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.PurchaseOrderDetail, Entities.PurchaseOrderDetail>(MemberList.None);
        }

        public partial class UpdatePurchaseOrderDetailRequestTarget
        {
            public int PurchaseOrderID { get; set; }
            public int PurchaseOrderDetailID { get; set; }

            public UpdatePurchaseOrderDetailRequestTarget()
            {
            }

            public UpdatePurchaseOrderDetailRequestTarget(int purchaseOrderID, int purchaseOrderDetailID)
            {
                PurchaseOrderID = purchaseOrderID;
                PurchaseOrderDetailID = purchaseOrderDetailID;
            }
        }
    }
}