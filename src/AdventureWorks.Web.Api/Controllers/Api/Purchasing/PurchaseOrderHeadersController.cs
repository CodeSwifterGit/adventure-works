using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.CreatePurchaseOrderHeader;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.DeletePurchaseOrderHeader;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.UpdatePurchaseOrderHeader;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaderDetail;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class PurchaseOrderHeadersController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{employeeID}")]
        [ProducesResponseType(typeof(PurchaseOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderHeadersListViewModel>> GetPurchaseOrderHeadersByEmployee(
            int employeeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderHeadersByEmployeeListQuery()
            {
                EmployeeID = employeeID,
                DataTable = DataTableInfo<PurchaseOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{shipMethodID}")]
        [ProducesResponseType(typeof(PurchaseOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderHeadersListViewModel>> GetPurchaseOrderHeadersByShipMethod(
            int shipMethodID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderHeadersByShipMethodListQuery()
            {
                ShipMethodID = shipMethodID,
                DataTable = DataTableInfo<PurchaseOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{vendorID}")]
        [ProducesResponseType(typeof(PurchaseOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderHeadersListViewModel>> GetPurchaseOrderHeadersByVendor(
            int vendorID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderHeadersByVendorListQuery()
            {
                VendorID = vendorID,
                DataTable = DataTableInfo<PurchaseOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{purchaseOrderID}")]
        [ProducesResponseType(typeof(PurchaseOrderHeaderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderHeaderLookupModel>> Get(int purchaseOrderID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderHeaderDetailQuery
            {
                PurchaseOrderID = purchaseOrderID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(PurchaseOrderHeaderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BasePurchaseOrderHeader model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreatePurchaseOrderHeaderCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<PurchaseOrderHeaderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BasePurchaseOrderHeader> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreatePurchaseOrderHeaderSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{purchaseOrderID}")]
        [ProducesResponseType(typeof(PurchaseOrderHeaderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int purchaseOrderID, UpdatePurchaseOrderHeaderCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<PurchaseOrderHeaderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdatePurchaseOrderHeaderCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdatePurchaseOrderHeaderSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{purchaseOrderID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int purchaseOrderID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeletePurchaseOrderHeaderCommand
            {
                PurchaseOrderID = purchaseOrderID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<PurchaseOrderHeaderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeletePurchaseOrderHeaderCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeletePurchaseOrderHeaderSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}