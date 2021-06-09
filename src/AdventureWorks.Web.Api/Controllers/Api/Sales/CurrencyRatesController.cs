using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.CreateCurrencyRate;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.DeleteCurrencyRate;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.UpdateCurrencyRate;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRateDetail;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class CurrencyRatesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{fromCurrencyCode}")]
        [ProducesResponseType(typeof(CurrencyRatesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CurrencyRatesListViewModel>> GetCurrencyRatesByCurrencyFrom(
            string fromCurrencyCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrencyRatesByCurrencyListQuery()
            {
                FromCurrencyCode = fromCurrencyCode,
                DataTable = DataTableInfo<CurrencyRateSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{toCurrencyCode}")]
        [ProducesResponseType(typeof(CurrencyRatesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CurrencyRatesListViewModel>> GetCurrencyRatesByCurrencyTo(
            string toCurrencyCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrencyRatesByCurrencyListQuery()
            {
                ToCurrencyCode = toCurrencyCode,
                DataTable = DataTableInfo<CurrencyRateSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{currencyRateID}")]
        [ProducesResponseType(typeof(CurrencyRateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CurrencyRateLookupModel>> Get(int currencyRateID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrencyRateDetailQuery
            {
                CurrencyRateID = currencyRateID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CurrencyRateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCurrencyRate model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCurrencyRateCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CurrencyRateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCurrencyRate> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCurrencyRateSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{currencyRateID}")]
        [ProducesResponseType(typeof(CurrencyRateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int currencyRateID, UpdateCurrencyRateCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CurrencyRateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCurrencyRateCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCurrencyRateSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{currencyRateID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int currencyRateID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCurrencyRateCommand
            {
                CurrencyRateID = currencyRateID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CurrencyRateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCurrencyRateCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCurrencyRateSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}