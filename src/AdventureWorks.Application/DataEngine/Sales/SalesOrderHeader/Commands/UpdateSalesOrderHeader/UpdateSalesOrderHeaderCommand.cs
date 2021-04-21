using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.UpdateSalesOrderHeader
{
    public partial class UpdateSalesOrderHeaderCommand : BaseSalesOrderHeader, IRequest<SalesOrderHeaderLookupModel>, IHaveCustomMapping
    {
        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
        public int? SalesPersonID { get; set; }
        public int? TerritoryID { get; set; }
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public int ShipMethodID { get; set; }
        public int? CreditCardID { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public int? CurrencyRateID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesOrderHeaderRequestTarget RequestTarget { get; set; }

        public UpdateSalesOrderHeaderCommand()
        {
        }

        public UpdateSalesOrderHeaderCommand(int salesOrderID, BaseSalesOrderHeader model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesOrderHeaderRequestTarget(salesOrderID);
        }

        public UpdateSalesOrderHeaderCommand(int salesOrderID)
        {
            SalesOrderID = salesOrderID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesOrderHeader, UpdateSalesOrderHeaderCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesOrderHeaderCommand, Entities.SalesOrderHeader>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesOrderHeader, Entities.SalesOrderHeader>(MemberList.None);
        }

        public partial class UpdateSalesOrderHeaderRequestTarget
        {
            public int SalesOrderID { get; set; }

            public UpdateSalesOrderHeaderRequestTarget()
            {
            }

            public UpdateSalesOrderHeaderRequestTarget(int salesOrderID)
            {
                SalesOrderID = salesOrderID;
            }
        }
    }
}