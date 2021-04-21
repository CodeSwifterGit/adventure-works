using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.UpdateSalesTerritory
{
    public partial class UpdateSalesTerritorySetCommand : IRequest<List<SalesTerritoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesTerritoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesTerritory>, List<UpdateSalesTerritoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesTerritoryCommand>, List<Entities.SalesTerritory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesTerritory>, List<Entities.SalesTerritory>>(MemberList.None);
        }
    }
}