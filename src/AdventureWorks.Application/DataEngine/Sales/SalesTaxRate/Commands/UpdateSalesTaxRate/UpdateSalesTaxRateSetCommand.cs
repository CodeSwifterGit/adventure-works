using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.UpdateSalesTaxRate
{
    public partial class UpdateSalesTaxRateSetCommand : IRequest<List<SalesTaxRateLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesTaxRateCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesTaxRate>, List<UpdateSalesTaxRateCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesTaxRateCommand>, List<Entities.SalesTaxRate>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesTaxRate>, List<Entities.SalesTaxRate>>(MemberList.None);
        }
    }
}