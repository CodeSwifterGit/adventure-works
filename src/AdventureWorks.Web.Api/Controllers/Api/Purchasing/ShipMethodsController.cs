using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.CreateShipMethod;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.DeleteShipMethod;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.UpdateShipMethod;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethodDetail;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class ShipMethodsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ShipMethodsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShipMethodsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetShipMethodsListQuery()
            {
                DataTable = DataTableInfo<ShipMethodSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{shipMethodID}")]
        [ProducesResponseType(typeof(ShipMethodLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShipMethodLookupModel>> Get(int shipMethodID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetShipMethodDetailQuery
            {
                ShipMethodID = shipMethodID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ShipMethodLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseShipMethod model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateShipMethodCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ShipMethodLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseShipMethod> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateShipMethodSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{shipMethodID}")]
        [ProducesResponseType(typeof(ShipMethodLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int shipMethodID, UpdateShipMethodCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ShipMethodLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateShipMethodCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateShipMethodSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{shipMethodID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int shipMethodID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteShipMethodCommand
            {
                ShipMethodID = shipMethodID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ShipMethodLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteShipMethodCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteShipMethodSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}