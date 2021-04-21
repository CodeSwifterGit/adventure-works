using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.UpdateCountryRegionCurrency
{
    public partial class UpdateCountryRegionCurrencySetCommand : IRequest<List<CountryRegionCurrencyLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCountryRegionCurrencyCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCountryRegionCurrency>, List<UpdateCountryRegionCurrencyCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCountryRegionCurrencyCommand>, List<Entities.CountryRegionCurrency>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.CountryRegionCurrency>, List<Entities.CountryRegionCurrency>>(MemberList.None);
        }
    }
}