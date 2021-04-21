using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.Illustration.Commands.CreateIllustration;
using AdventureWorks.Application.DataEngine.Production.Illustration.Commands.DeleteIllustration;
using AdventureWorks.Application.DataEngine.Production.Illustration.Commands.UpdateIllustration;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrationDetail;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class IllustrationsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(IllustrationsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IllustrationsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetIllustrationsListQuery()
            {
                DataTable = DataTableInfo<IllustrationSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{illustrationID}")]
        [ProducesResponseType(typeof(IllustrationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IllustrationLookupModel>> Get(int illustrationID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetIllustrationDetailQuery
            {
                IllustrationID = illustrationID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(IllustrationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseIllustration model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateIllustrationCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<IllustrationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseIllustration> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateIllustrationSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{illustrationID}")]
        [ProducesResponseType(typeof(IllustrationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int illustrationID, UpdateIllustrationCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<IllustrationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateIllustrationCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateIllustrationSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{illustrationID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int illustrationID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteIllustrationCommand
            {
                IllustrationID = illustrationID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<IllustrationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteIllustrationCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteIllustrationSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}