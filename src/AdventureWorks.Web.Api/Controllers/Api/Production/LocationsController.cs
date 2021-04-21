using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.Location.Commands.CreateLocation;
using AdventureWorks.Application.DataEngine.Production.Location.Commands.DeleteLocation;
using AdventureWorks.Application.DataEngine.Production.Location.Commands.UpdateLocation;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocationDetail;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class LocationsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(LocationsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LocationsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetLocationsListQuery()
            {
                DataTable = DataTableInfo<LocationSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{locationID}")]
        [ProducesResponseType(typeof(LocationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LocationLookupModel>> Get(short locationID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetLocationDetailQuery
            {
                LocationID = locationID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(LocationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseLocation model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateLocationCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<LocationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseLocation> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateLocationSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{locationID}")]
        [ProducesResponseType(typeof(LocationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(short locationID, UpdateLocationCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<LocationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateLocationCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateLocationSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{locationID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(short locationID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteLocationCommand
            {
                LocationID = locationID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<LocationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteLocationCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteLocationSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}