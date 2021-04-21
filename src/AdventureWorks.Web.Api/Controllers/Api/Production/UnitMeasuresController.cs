using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.CreateUnitMeasure;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.DeleteUnitMeasure;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.UpdateUnitMeasure;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasureDetail;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class UnitMeasuresController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(UnitMeasuresListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UnitMeasuresListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetUnitMeasuresListQuery()
            {
                DataTable = DataTableInfo<UnitMeasureSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{unitMeasureCode}")]
        [ProducesResponseType(typeof(UnitMeasureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UnitMeasureLookupModel>> Get(string unitMeasureCode, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetUnitMeasureDetailQuery
            {
                UnitMeasureCode = unitMeasureCode
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(UnitMeasureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseUnitMeasure model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateUnitMeasureCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<UnitMeasureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseUnitMeasure> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateUnitMeasureSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{unitMeasureCode}")]
        [ProducesResponseType(typeof(UnitMeasureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(string unitMeasureCode, UpdateUnitMeasureCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<UnitMeasureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateUnitMeasureCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateUnitMeasureSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{unitMeasureCode}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string unitMeasureCode, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteUnitMeasureCommand
            {
                UnitMeasureCode = unitMeasureCode
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<UnitMeasureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteUnitMeasureCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteUnitMeasureSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}