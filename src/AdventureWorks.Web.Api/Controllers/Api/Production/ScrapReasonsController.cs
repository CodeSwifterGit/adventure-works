using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.CreateScrapReason;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.DeleteScrapReason;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.UpdateScrapReason;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasonDetail;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ScrapReasonsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ScrapReasonsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ScrapReasonsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetScrapReasonsListQuery()
            {
                DataTable = DataTableInfo<ScrapReasonSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{scrapReasonID}")]
        [ProducesResponseType(typeof(ScrapReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ScrapReasonLookupModel>> Get(short scrapReasonID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetScrapReasonDetailQuery
            {
                ScrapReasonID = scrapReasonID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ScrapReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseScrapReason model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateScrapReasonCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ScrapReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseScrapReason> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateScrapReasonSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{scrapReasonID}")]
        [ProducesResponseType(typeof(ScrapReasonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(short scrapReasonID, UpdateScrapReasonCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ScrapReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateScrapReasonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateScrapReasonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{scrapReasonID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(short scrapReasonID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteScrapReasonCommand
            {
                ScrapReasonID = scrapReasonID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ScrapReasonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteScrapReasonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteScrapReasonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}