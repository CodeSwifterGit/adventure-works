using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.CreateCountryRegionCurrency;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.DeleteCountryRegionCurrency;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.UpdateCountryRegionCurrency;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencyDetail;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class CountryRegionCurrenciesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{countryRegionCode}")]
        [ProducesResponseType(typeof(CountryRegionCurrenciesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CountryRegionCurrenciesListViewModel>> GetCountryRegionCurrenciesByCountryRegion(
            string countryRegionCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCountryRegionCurrenciesByCountryRegionListQuery()
            {
                CountryRegionCode = countryRegionCode,
                DataTable = DataTableInfo<CountryRegionCurrencySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{currencyCode}")]
        [ProducesResponseType(typeof(CountryRegionCurrenciesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CountryRegionCurrenciesListViewModel>> GetCountryRegionCurrenciesByCurrency(
            string currencyCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCountryRegionCurrenciesByCurrencyListQuery()
            {
                CurrencyCode = currencyCode,
                DataTable = DataTableInfo<CountryRegionCurrencySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{countryRegionCode}/{currencyCode}")]
        [ProducesResponseType(typeof(CountryRegionCurrencyLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CountryRegionCurrencyLookupModel>> Get(string countryRegionCode, string currencyCode, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCountryRegionCurrencyDetailQuery
            {
                CountryRegionCode = countryRegionCode,
                CurrencyCode = currencyCode
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CountryRegionCurrencyLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCountryRegionCurrency model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCountryRegionCurrencyCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CountryRegionCurrencyLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCountryRegionCurrency> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCountryRegionCurrencySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{countryRegionCode}/{currencyCode}")]
        [ProducesResponseType(typeof(CountryRegionCurrencyLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(string countryRegionCode, string currencyCode, UpdateCountryRegionCurrencyCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CountryRegionCurrencyLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCountryRegionCurrencyCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCountryRegionCurrencySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{countryRegionCode}/{currencyCode}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string countryRegionCode, string currencyCode, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCountryRegionCurrencyCommand
            {
                CountryRegionCode = countryRegionCode,
                CurrencyCode = currencyCode
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CountryRegionCurrencyLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCountryRegionCurrencyCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCountryRegionCurrencySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}