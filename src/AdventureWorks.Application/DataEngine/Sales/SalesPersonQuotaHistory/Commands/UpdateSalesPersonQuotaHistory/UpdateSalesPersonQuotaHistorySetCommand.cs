using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.UpdateSalesPersonQuotaHistory
{
    public partial class UpdateSalesPersonQuotaHistorySetCommand : IRequest<List<SalesPersonQuotaHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesPersonQuotaHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesPersonQuotaHistory>, List<UpdateSalesPersonQuotaHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesPersonQuotaHistoryCommand>, List<Entities.SalesPersonQuotaHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesPersonQuotaHistory>, List<Entities.SalesPersonQuotaHistory>>(MemberList.None);
        }
    }
}