using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.UpdatePurchaseOrderHeader
{
    public partial class UpdatePurchaseOrderHeaderCommand : BasePurchaseOrderHeader, IRequest<PurchaseOrderHeaderLookupModel>, IHaveCustomMapping
    {
        public int PurchaseOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public byte Status { get; set; }
        public int EmployeeID { get; set; }
        public int VendorID { get; set; }
        public int ShipMethodID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdatePurchaseOrderHeaderRequestTarget RequestTarget { get; set; }

        public UpdatePurchaseOrderHeaderCommand()
        {
        }

        public UpdatePurchaseOrderHeaderCommand(int purchaseOrderID, BasePurchaseOrderHeader model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdatePurchaseOrderHeaderRequestTarget(purchaseOrderID);
        }

        public UpdatePurchaseOrderHeaderCommand(int purchaseOrderID)
        {
            PurchaseOrderID = purchaseOrderID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BasePurchaseOrderHeader, UpdatePurchaseOrderHeaderCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdatePurchaseOrderHeaderCommand, Entities.PurchaseOrderHeader>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.PurchaseOrderHeader, Entities.PurchaseOrderHeader>(MemberList.None);
        }

        public partial class UpdatePurchaseOrderHeaderRequestTarget
        {
            public int PurchaseOrderID { get; set; }

            public UpdatePurchaseOrderHeaderRequestTarget()
            {
            }

            public UpdatePurchaseOrderHeaderRequestTarget(int purchaseOrderID)
            {
                PurchaseOrderID = purchaseOrderID;
            }
        }
    }
}