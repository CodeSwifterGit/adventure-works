using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.CreateSalesOrderHeaderSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.DeleteSalesOrderHeaderSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.UpdateSalesOrderHeaderSalesReason;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasonDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesOrderHeaderSalesReasonsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesOrderID}")]
        [ProducesResponseType(typeof(SalesOrderHeaderSalesReasonsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeaderSalesReasonsListViewModel>> GetSalesOrderHeaderSalesReasonsBySalesOrderHeader(
            int salesOrderID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeaderSalesReasonsBySalesOrderHeaderListQuery()
            {
                SalesOrderID = salesOrderID,
                DataTable = DataTableInfo<SalesOrderHeaderSalesReasonSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesReasonID}")]
        [ProducesResponseType(typeof(SalesOrderHeaderSalesReasonsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeaderSalesReasonsListViewModel>> GetSalesOrderHeaderSalesReasonsBySalesReason(
            int salesReasonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeaderSalesReasonsBySalesReasonListQuery()
            {
                SalesReasonID = salesReasonID,
                DataTable = DataTableInfo<SalesOrderHeaderSalesReasonSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesOrderID}/{salesReasonID}")]
        [ProducesResponseType(typeof(SalesOrderHeaderSalesReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeaderSalesReasonLookupModel>> Get(int salesOrderID, int salesReasonID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeaderSalesReasonDetailQuery
            {
                SalesOrderID = salesOrderID,
                SalesReasonID = salesReasonID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesOrderHeaderSalesReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesOrderHeaderSalesReason model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesOrderHeaderSalesReasonCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderHeaderSalesReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesOrderHeaderSalesReason> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesOrderHeaderSalesReasonSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesOrderID}/{salesReasonID}")]
        [ProducesResponseType(typeof(SalesOrderHeaderSalesReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesOrderID, int salesReasonID, UpdateSalesOrderHeaderSalesReasonCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderHeaderSalesReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesOrderHeaderSalesReasonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesOrderHeaderSalesReasonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesOrderID}/{salesReasonID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesOrderID, int salesReasonID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesOrderHeaderSalesReasonCommand
            {
                SalesOrderID = salesOrderID,
                SalesReasonID = salesReasonID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderHeaderSalesReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesOrderHeaderSalesReasonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesOrderHeaderSalesReasonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}