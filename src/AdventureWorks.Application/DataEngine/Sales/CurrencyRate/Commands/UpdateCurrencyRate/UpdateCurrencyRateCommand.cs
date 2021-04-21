using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.UpdateCurrencyRate
{
    public partial class UpdateCurrencyRateCommand : BaseCurrencyRate, IRequest<CurrencyRateLookupModel>, IHaveCustomMapping
    {
        public int CurrencyRateID { get; set; }
        public DateTime CurrencyRateDate { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal AverageRate { get; set; }
        public decimal EndOfDayRate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCurrencyRateRequestTarget RequestTarget { get; set; }

        public UpdateCurrencyRateCommand()
        {
        }

        public UpdateCurrencyRateCommand(int currencyRateID, BaseCurrencyRate model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCurrencyRateRequestTarget(currencyRateID);
        }

        public UpdateCurrencyRateCommand(int currencyRateID)
        {
            CurrencyRateID = currencyRateID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCurrencyRate, UpdateCurrencyRateCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCurrencyRateCommand, Entities.CurrencyRate>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.CurrencyRate, Entities.CurrencyRate>(MemberList.None);
        }

        public partial class UpdateCurrencyRateRequestTarget
        {
            public int CurrencyRateID { get; set; }

            public UpdateCurrencyRateRequestTarget()
            {
            }

            public UpdateCurrencyRateRequestTarget(int currencyRateID)
            {
                CurrencyRateID = currencyRateID;
            }
        }
    }
}