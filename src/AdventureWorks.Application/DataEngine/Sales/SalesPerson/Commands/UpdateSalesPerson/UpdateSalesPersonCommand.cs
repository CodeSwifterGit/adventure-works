using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.UpdateSalesPerson
{
    public partial class UpdateSalesPersonCommand : IRequest<SalesPersonLookupModel>, IHaveCustomMapping
    {
        public int SalesPersonID { get; set; }
        public int? TerritoryID { get; set; }
        public decimal? SalesQuota { get; set; }
        public decimal Bonus { get; set; }
        public decimal CommissionPct { get; set; }
        public decimal SalesYTD { get; set; }
        public decimal SalesLastYear { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesPersonRequestTarget RequestTarget { get; set; }

        public UpdateSalesPersonCommand()
        {
        }

        public UpdateSalesPersonCommand(int salesPersonID, BaseSalesPerson model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesPersonRequestTarget(salesPersonID);
        }

        public UpdateSalesPersonCommand(int salesPersonID)
        {
            SalesPersonID = salesPersonID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesPerson, UpdateSalesPersonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesPersonCommand, Entities.SalesPerson>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesPerson, Entities.SalesPerson>(MemberList.None);
        }

        public partial class UpdateSalesPersonRequestTarget
        {
            public int SalesPersonID { get; set; }

            public UpdateSalesPersonRequestTarget()
            {
            }

            public UpdateSalesPersonRequestTarget(int salesPersonID)
            {
                SalesPersonID = salesPersonID;
            }
        }
    }
}