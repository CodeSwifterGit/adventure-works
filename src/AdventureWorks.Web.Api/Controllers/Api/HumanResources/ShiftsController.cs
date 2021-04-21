using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.CreateShift;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.DeleteShift;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.UpdateShift;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShiftDetail;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class ShiftsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ShiftsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShiftsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetShiftsListQuery()
            {
                DataTable = DataTableInfo<ShiftSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{shiftID}")]
        [ProducesResponseType(typeof(ShiftLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShiftLookupModel>> Get(byte shiftID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetShiftDetailQuery
            {
                ShiftID = shiftID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ShiftLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseShift model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateShiftCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ShiftLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseShift> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateShiftSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{shiftID}")]
        [ProducesResponseType(typeof(ShiftLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(byte shiftID, UpdateShiftCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ShiftLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateShiftCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateShiftSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{shiftID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(byte shiftID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteShiftCommand
            {
                ShiftID = shiftID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ShiftLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteShiftCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteShiftSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}