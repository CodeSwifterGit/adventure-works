using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.UpdateCurrencyRate
{
    public partial class UpdateCurrencyRateSetCommand : IRequest<List<CurrencyRateLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCurrencyRateCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCurrencyRate>, List<UpdateCurrencyRateCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCurrencyRateCommand>, List<Entities.CurrencyRate>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.CurrencyRate>, List<Entities.CurrencyRate>>(MemberList.None);
        }
    }
}