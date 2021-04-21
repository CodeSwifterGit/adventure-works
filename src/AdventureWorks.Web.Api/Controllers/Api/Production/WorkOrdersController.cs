using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.CreateWorkOrder;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.DeleteWorkOrder;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.UpdateWorkOrder;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrderDetail;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class WorkOrdersController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(WorkOrdersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<WorkOrdersListViewModel>> GetWorkOrdersByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetWorkOrdersByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<WorkOrderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{scrapReasonID}")]
        [ProducesResponseType(typeof(WorkOrdersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<WorkOrdersListViewModel>> GetWorkOrdersByScrapReason(
            short? scrapReasonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetWorkOrdersByScrapReasonListQuery()
            {
                ScrapReasonID = scrapReasonID,
                DataTable = DataTableInfo<WorkOrderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{workOrderID}")]
        [ProducesResponseType(typeof(WorkOrderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<WorkOrderLookupModel>> Get(int workOrderID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetWorkOrderDetailQuery
            {
                WorkOrderID = workOrderID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(WorkOrderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseWorkOrder model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateWorkOrderCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<WorkOrderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseWorkOrder> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateWorkOrderSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{workOrderID}")]
        [ProducesResponseType(typeof(WorkOrderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int workOrderID, UpdateWorkOrderCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<WorkOrderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateWorkOrderCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateWorkOrderSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{workOrderID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int workOrderID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteWorkOrderCommand
            {
                WorkOrderID = workOrderID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<WorkOrderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteWorkOrderCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteWorkOrderSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}