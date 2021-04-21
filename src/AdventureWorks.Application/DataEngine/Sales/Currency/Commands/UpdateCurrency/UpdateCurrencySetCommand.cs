using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.UpdateCurrency
{
    public partial class UpdateCurrencySetCommand : IRequest<List<CurrencyLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCurrencyCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCurrency>, List<UpdateCurrencyCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCurrencyCommand>, List<Entities.Currency>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Currency>, List<Entities.Currency>>(MemberList.None);
        }
    }
}