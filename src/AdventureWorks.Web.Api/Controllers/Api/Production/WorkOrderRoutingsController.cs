using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.CreateWorkOrderRouting;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.DeleteWorkOrderRouting;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.UpdateWorkOrderRouting;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutingDetail;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class WorkOrderRoutingsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{locationID}")]
        [ProducesResponseType(typeof(WorkOrderRoutingsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<WorkOrderRoutingsListViewModel>> GetWorkOrderRoutingsByLocation(
            short locationID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetWorkOrderRoutingsByLocationListQuery()
            {
                LocationID = locationID,
                DataTable = DataTableInfo<WorkOrderRoutingSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{workOrderID}")]
        [ProducesResponseType(typeof(WorkOrderRoutingsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<WorkOrderRoutingsListViewModel>> GetWorkOrderRoutingsByWorkOrder(
            int workOrderID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetWorkOrderRoutingsByWorkOrderListQuery()
            {
                WorkOrderID = workOrderID,
                DataTable = DataTableInfo<WorkOrderRoutingSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{workOrderID}/{productID}/{operationSequence}")]
        [ProducesResponseType(typeof(WorkOrderRoutingLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<WorkOrderRoutingLookupModel>> Get(int workOrderID, int productID, short operationSequence, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetWorkOrderRoutingDetailQuery
            {
                WorkOrderID = workOrderID,
                ProductID = productID,
                OperationSequence = operationSequence
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(WorkOrderRoutingLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseWorkOrderRouting model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateWorkOrderRoutingCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<WorkOrderRoutingLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseWorkOrderRouting> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateWorkOrderRoutingSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{workOrderID}/{productID}/{operationSequence}")]
        [ProducesResponseType(typeof(WorkOrderRoutingLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int workOrderID, int productID, short operationSequence, UpdateWorkOrderRoutingCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<WorkOrderRoutingLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateWorkOrderRoutingCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateWorkOrderRoutingSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{workOrderID}/{productID}/{operationSequence}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int workOrderID, int productID, short operationSequence, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteWorkOrderRoutingCommand
            {
                WorkOrderID = workOrderID,
                ProductID = productID,
                OperationSequence = operationSequence
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<WorkOrderRoutingLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteWorkOrderRoutingCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteWorkOrderRoutingSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}