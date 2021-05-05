using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.UpdateCurrency
{
    public partial class UpdateCurrencyCommand : IRequest<CurrencyLookupModel>, IHaveCustomMapping
    {
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCurrencyRequestTarget RequestTarget { get; set; }

        public UpdateCurrencyCommand()
        {
        }

        public UpdateCurrencyCommand(string currencyCode, BaseCurrency model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCurrencyRequestTarget(currencyCode);
        }

        public UpdateCurrencyCommand(string currencyCode)
        {
            CurrencyCode = currencyCode;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCurrency, UpdateCurrencyCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCurrencyCommand, Entities.Currency>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Currency, Entities.Currency>(MemberList.None);
        }

        public partial class UpdateCurrencyRequestTarget
        {
            public string CurrencyCode { get; set; }

            public UpdateCurrencyRequestTarget()
            {
            }

            public UpdateCurrencyRequestTarget(string currencyCode)
            {
                CurrencyCode = currencyCode;
            }
        }
    }
}