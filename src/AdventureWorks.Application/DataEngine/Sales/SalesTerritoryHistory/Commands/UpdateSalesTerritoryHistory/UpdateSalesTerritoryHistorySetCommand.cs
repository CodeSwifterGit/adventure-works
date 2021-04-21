using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.UpdateSalesTerritoryHistory
{
    public partial class UpdateSalesTerritoryHistorySetCommand : IRequest<List<SalesTerritoryHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesTerritoryHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesTerritoryHistory>, List<UpdateSalesTerritoryHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesTerritoryHistoryCommand>, List<Entities.SalesTerritoryHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesTerritoryHistory>, List<Entities.SalesTerritoryHistory>>(MemberList.None);
        }
    }
}