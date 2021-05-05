using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.UpdateSalesTerritory
{
    public partial class UpdateSalesTerritoryCommand : IRequest<SalesTerritoryLookupModel>, IHaveCustomMapping
    {
        public int TerritoryID { get; set; }
        public string Name { get; set; }
        public string CountryRegionCode { get; set; }
        public string Group { get; set; }
        public decimal SalesYTD { get; set; }
        public decimal SalesLastYear { get; set; }
        public decimal CostYTD { get; set; }
        public decimal CostLastYear { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesTerritoryRequestTarget RequestTarget { get; set; }

        public UpdateSalesTerritoryCommand()
        {
        }

        public UpdateSalesTerritoryCommand(int territoryID, BaseSalesTerritory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesTerritoryRequestTarget(territoryID);
        }

        public UpdateSalesTerritoryCommand(int territoryID)
        {
            TerritoryID = territoryID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesTerritory, UpdateSalesTerritoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesTerritoryCommand, Entities.SalesTerritory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesTerritory, Entities.SalesTerritory>(MemberList.None);
        }

        public partial class UpdateSalesTerritoryRequestTarget
        {
            public int TerritoryID { get; set; }

            public UpdateSalesTerritoryRequestTarget()
            {
            }

            public UpdateSalesTerritoryRequestTarget(int territoryID)
            {
                TerritoryID = territoryID;
            }
        }
    }
}