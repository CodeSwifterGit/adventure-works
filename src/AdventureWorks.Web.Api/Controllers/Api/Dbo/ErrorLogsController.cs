using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.CreateErrorLog;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.DeleteErrorLog;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.UpdateErrorLog;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogDetail;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Dbo
{
    public partial class ErrorLogsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ErrorLogsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ErrorLogsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetErrorLogsListQuery()
            {
                DataTable = DataTableInfo<ErrorLogSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{errorLogID}")]
        [ProducesResponseType(typeof(ErrorLogLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ErrorLogLookupModel>> Get(int errorLogID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetErrorLogDetailQuery
            {
                ErrorLogID = errorLogID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ErrorLogLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseErrorLog model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateErrorLogCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ErrorLogLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseErrorLog> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateErrorLogSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{errorLogID}")]
        [ProducesResponseType(typeof(ErrorLogLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int errorLogID, UpdateErrorLogCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ErrorLogLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateErrorLogCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateErrorLogSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{errorLogID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int errorLogID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteErrorLogCommand
            {
                ErrorLogID = errorLogID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ErrorLogLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteErrorLogCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteErrorLogSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}