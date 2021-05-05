using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.UpdateSalesTerritoryHistory
{
    public partial class UpdateSalesTerritoryHistoryCommand : IRequest<SalesTerritoryHistoryLookupModel>, IHaveCustomMapping
    {
        public int SalesPersonID { get; set; }
        public int TerritoryID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesTerritoryHistoryRequestTarget RequestTarget { get; set; }

        public UpdateSalesTerritoryHistoryCommand()
        {
        }

        public UpdateSalesTerritoryHistoryCommand(int salesPersonID, int territoryID, DateTime startDate, BaseSalesTerritoryHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesTerritoryHistoryRequestTarget(salesPersonID, territoryID, startDate);
        }

        public UpdateSalesTerritoryHistoryCommand(int salesPersonID, int territoryID, DateTime startDate)
        {
            SalesPersonID = salesPersonID;
            TerritoryID = territoryID;
            StartDate = startDate;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesTerritoryHistory, UpdateSalesTerritoryHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesTerritoryHistoryCommand, Entities.SalesTerritoryHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesTerritoryHistory, Entities.SalesTerritoryHistory>(MemberList.None);
        }

        public partial class UpdateSalesTerritoryHistoryRequestTarget
        {
            public int SalesPersonID { get; set; }
            public int TerritoryID { get; set; }
            public DateTime StartDate { get; set; }

            public UpdateSalesTerritoryHistoryRequestTarget()
            {
            }

            public UpdateSalesTerritoryHistoryRequestTarget(int salesPersonID, int territoryID, DateTime startDate)
            {
                SalesPersonID = salesPersonID;
                TerritoryID = territoryID;
                StartDate = startDate;
            }
        }
    }
}