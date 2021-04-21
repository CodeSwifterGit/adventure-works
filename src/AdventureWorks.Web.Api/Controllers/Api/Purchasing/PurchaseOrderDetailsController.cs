using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.CreatePurchaseOrderDetail;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.DeletePurchaseOrderDetail;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.UpdatePurchaseOrderDetail;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetailDetail;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class PurchaseOrderDetailsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(PurchaseOrderDetailsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderDetailsListViewModel>> GetPurchaseOrderDetailsByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderDetailsByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<PurchaseOrderDetailSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{purchaseOrderID}")]
        [ProducesResponseType(typeof(PurchaseOrderDetailsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderDetailsListViewModel>> GetPurchaseOrderDetailsByPurchaseOrderHeader(
            int purchaseOrderID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderDetailsByPurchaseOrderHeaderListQuery()
            {
                PurchaseOrderID = purchaseOrderID,
                DataTable = DataTableInfo<PurchaseOrderDetailSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{purchaseOrderID}/{purchaseOrderDetailID}")]
        [ProducesResponseType(typeof(PurchaseOrderDetailLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderDetailLookupModel>> Get(int purchaseOrderID, int purchaseOrderDetailID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetPurchaseOrderDetailDetailQuery
            {
                PurchaseOrderID = purchaseOrderID,
                PurchaseOrderDetailID = purchaseOrderDetailID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(PurchaseOrderDetailLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BasePurchaseOrderDetail model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreatePurchaseOrderDetailCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<PurchaseOrderDetailLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BasePurchaseOrderDetail> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreatePurchaseOrderDetailSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{purchaseOrderID}/{purchaseOrderDetailID}")]
        [ProducesResponseType(typeof(PurchaseOrderDetailLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int purchaseOrderID, int purchaseOrderDetailID, UpdatePurchaseOrderDetailCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<PurchaseOrderDetailLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdatePurchaseOrderDetailCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdatePurchaseOrderDetailSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{purchaseOrderID}/{purchaseOrderDetailID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int purchaseOrderID, int purchaseOrderDetailID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeletePurchaseOrderDetailCommand
            {
                PurchaseOrderID = purchaseOrderID,
                PurchaseOrderDetailID = purchaseOrderDetailID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<PurchaseOrderDetailLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeletePurchaseOrderDetailCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeletePurchaseOrderDetailSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}