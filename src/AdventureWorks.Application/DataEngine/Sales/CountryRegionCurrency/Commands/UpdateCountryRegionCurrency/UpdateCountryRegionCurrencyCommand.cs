using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.UpdateCountryRegionCurrency
{
    public partial class UpdateCountryRegionCurrencyCommand : IRequest<CountryRegionCurrencyLookupModel>, IHaveCustomMapping
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCountryRegionCurrencyRequestTarget RequestTarget { get; set; }

        public UpdateCountryRegionCurrencyCommand()
        {
        }

        public UpdateCountryRegionCurrencyCommand(string countryRegionCode, string currencyCode, BaseCountryRegionCurrency model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCountryRegionCurrencyRequestTarget(countryRegionCode, currencyCode);
        }

        public UpdateCountryRegionCurrencyCommand(string countryRegionCode, string currencyCode)
        {
            CountryRegionCode = countryRegionCode;
            CurrencyCode = currencyCode;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCountryRegionCurrency, UpdateCountryRegionCurrencyCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCountryRegionCurrencyCommand, Entities.CountryRegionCurrency>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.CountryRegionCurrency, Entities.CountryRegionCurrency>(MemberList.None);
        }

        public partial class UpdateCountryRegionCurrencyRequestTarget
        {
            public string CountryRegionCode { get; set; }
            public string CurrencyCode { get; set; }

            public UpdateCountryRegionCurrencyRequestTarget()
            {
            }

            public UpdateCountryRegionCurrencyRequestTarget(string countryRegionCode, string currencyCode)
            {
                CountryRegionCode = countryRegionCode;
                CurrencyCode = currencyCode;
            }
        }
    }
}