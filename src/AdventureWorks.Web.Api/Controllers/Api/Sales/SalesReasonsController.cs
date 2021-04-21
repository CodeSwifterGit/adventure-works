using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.CreateSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.DeleteSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.UpdateSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasonDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesReasonsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(SalesReasonsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesReasonsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesReasonsListQuery()
            {
                DataTable = DataTableInfo<SalesReasonSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesReasonID}")]
        [ProducesResponseType(typeof(SalesReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesReasonLookupModel>> Get(int salesReasonID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesReasonDetailQuery
            {
                SalesReasonID = salesReasonID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesReason model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesReasonCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesReason> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesReasonSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesReasonID}")]
        [ProducesResponseType(typeof(SalesReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesReasonID, UpdateSalesReasonCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesReasonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesReasonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesReasonID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesReasonID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesReasonCommand
            {
                SalesReasonID = salesReasonID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesReasonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesReasonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}