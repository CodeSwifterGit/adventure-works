using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.CreateSalesTaxRate;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.DeleteSalesTaxRate;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.UpdateSalesTaxRate;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRateDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesTaxRatesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{stateProvinceID}")]
        [ProducesResponseType(typeof(SalesTaxRatesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTaxRatesListViewModel>> GetSalesTaxRatesByStateProvince(
            int stateProvinceID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTaxRatesByStateProvinceListQuery()
            {
                StateProvinceID = stateProvinceID,
                DataTable = DataTableInfo<SalesTaxRateSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesTaxRateID}")]
        [ProducesResponseType(typeof(SalesTaxRateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTaxRateLookupModel>> Get(int salesTaxRateID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTaxRateDetailQuery
            {
                SalesTaxRateID = salesTaxRateID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesTaxRateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesTaxRate model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesTaxRateCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesTaxRateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesTaxRate> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesTaxRateSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesTaxRateID}")]
        [ProducesResponseType(typeof(SalesTaxRateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesTaxRateID, UpdateSalesTaxRateCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesTaxRateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesTaxRateCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesTaxRateSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesTaxRateID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesTaxRateID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesTaxRateCommand
            {
                SalesTaxRateID = salesTaxRateID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesTaxRateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesTaxRateCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesTaxRateSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}