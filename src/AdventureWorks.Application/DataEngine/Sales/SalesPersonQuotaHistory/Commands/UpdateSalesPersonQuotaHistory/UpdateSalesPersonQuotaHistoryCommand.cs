using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.UpdateSalesPersonQuotaHistory
{
    public partial class UpdateSalesPersonQuotaHistoryCommand : BaseSalesPersonQuotaHistory, IRequest<SalesPersonQuotaHistoryLookupModel>, IHaveCustomMapping
    {
        public int SalesPersonID { get; set; }
        public DateTime QuotaDate { get; set; }
        public decimal SalesQuota { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesPersonQuotaHistoryRequestTarget RequestTarget { get; set; }

        public UpdateSalesPersonQuotaHistoryCommand()
        {
        }

        public UpdateSalesPersonQuotaHistoryCommand(int salesPersonID, DateTime quotaDate, BaseSalesPersonQuotaHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesPersonQuotaHistoryRequestTarget(salesPersonID, quotaDate);
        }

        public UpdateSalesPersonQuotaHistoryCommand(int salesPersonID, DateTime quotaDate)
        {
            SalesPersonID = salesPersonID;
            QuotaDate = quotaDate;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesPersonQuotaHistory, UpdateSalesPersonQuotaHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesPersonQuotaHistoryCommand, Entities.SalesPersonQuotaHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesPersonQuotaHistory, Entities.SalesPersonQuotaHistory>(MemberList.None);
        }

        public partial class UpdateSalesPersonQuotaHistoryRequestTarget
        {
            public int SalesPersonID { get; set; }
            public DateTime QuotaDate { get; set; }

            public UpdateSalesPersonQuotaHistoryRequestTarget()
            {
            }

            public UpdateSalesPersonQuotaHistoryRequestTarget(int salesPersonID, DateTime quotaDate)
            {
                SalesPersonID = salesPersonID;
                QuotaDate = quotaDate;
            }
        }
    }
}