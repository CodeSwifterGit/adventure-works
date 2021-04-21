using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.Culture.Commands.CreateCulture;
using AdventureWorks.Application.DataEngine.Production.Culture.Commands.DeleteCulture;
using AdventureWorks.Application.DataEngine.Production.Culture.Commands.UpdateCulture;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultureDetail;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class CulturesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(CulturesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CulturesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCulturesListQuery()
            {
                DataTable = DataTableInfo<CultureSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{cultureID}")]
        [ProducesResponseType(typeof(CultureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CultureLookupModel>> Get(string cultureID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCultureDetailQuery
            {
                CultureID = cultureID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CultureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCulture model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCultureCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CultureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCulture> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCultureSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{cultureID}")]
        [ProducesResponseType(typeof(CultureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(string cultureID, UpdateCultureCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CultureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCultureCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCultureSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{cultureID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string cultureID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCultureCommand
            {
                CultureID = cultureID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CultureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCultureCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCultureSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}