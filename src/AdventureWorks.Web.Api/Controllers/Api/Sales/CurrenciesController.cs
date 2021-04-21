using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.Currency.Commands.CreateCurrency;
using AdventureWorks.Application.DataEngine.Sales.Currency.Commands.DeleteCurrency;
using AdventureWorks.Application.DataEngine.Sales.Currency.Commands.UpdateCurrency;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencyDetail;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class CurrenciesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(CurrenciesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CurrenciesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrenciesListQuery()
            {
                DataTable = DataTableInfo<CurrencySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{currencyCode}")]
        [ProducesResponseType(typeof(CurrencyLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CurrencyLookupModel>> Get(string currencyCode, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrencyDetailQuery
            {
                CurrencyCode = currencyCode
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CurrencyLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCurrency model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCurrencyCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CurrencyLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCurrency> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCurrencySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{currencyCode}")]
        [ProducesResponseType(typeof(CurrencyLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(string currencyCode, UpdateCurrencyCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CurrencyLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCurrencyCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCurrencySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{currencyCode}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string currencyCode, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCurrencyCommand
            {
                CurrencyCode = currencyCode
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CurrencyLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCurrencyCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCurrencySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}