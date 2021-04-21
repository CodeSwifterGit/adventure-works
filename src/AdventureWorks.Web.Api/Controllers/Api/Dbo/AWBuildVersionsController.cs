using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.CreateAWBuildVersion;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.DeleteAWBuildVersion;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.UpdateAWBuildVersion;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersionDetail;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Dbo
{
    public partial class AWBuildVersionsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(AWBuildVersionsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AWBuildVersionsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAWBuildVersionsListQuery()
            {
                DataTable = DataTableInfo<AWBuildVersionSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{systemInformationID}")]
        [ProducesResponseType(typeof(AWBuildVersionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AWBuildVersionLookupModel>> Get(byte systemInformationID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAWBuildVersionDetailQuery
            {
                SystemInformationID = systemInformationID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(AWBuildVersionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseAWBuildVersion model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateAWBuildVersionCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<AWBuildVersionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseAWBuildVersion> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateAWBuildVersionSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{systemInformationID}")]
        [ProducesResponseType(typeof(AWBuildVersionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(byte systemInformationID, UpdateAWBuildVersionCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<AWBuildVersionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateAWBuildVersionCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateAWBuildVersionSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{systemInformationID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(byte systemInformationID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteAWBuildVersionCommand
            {
                SystemInformationID = systemInformationID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<AWBuildVersionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteAWBuildVersionCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteAWBuildVersionSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}