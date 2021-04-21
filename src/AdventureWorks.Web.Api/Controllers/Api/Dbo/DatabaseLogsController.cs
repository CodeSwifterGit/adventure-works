using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.CreateDatabaseLog;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.DeleteDatabaseLog;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.UpdateDatabaseLog;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogDetail;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Dbo
{
    public partial class DatabaseLogsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(DatabaseLogsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DatabaseLogsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDatabaseLogsListQuery()
            {
                DataTable = DataTableInfo<DatabaseLogSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{databaseLogID}")]
        [ProducesResponseType(typeof(DatabaseLogLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DatabaseLogLookupModel>> Get(int databaseLogID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDatabaseLogDetailQuery
            {
                DatabaseLogID = databaseLogID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(DatabaseLogLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseDatabaseLog model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateDatabaseLogCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<DatabaseLogLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseDatabaseLog> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateDatabaseLogSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{databaseLogID}")]
        [ProducesResponseType(typeof(DatabaseLogLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int databaseLogID, UpdateDatabaseLogCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<DatabaseLogLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateDatabaseLogCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateDatabaseLogSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{databaseLogID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int databaseLogID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteDatabaseLogCommand
            {
                DatabaseLogID = databaseLogID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<DatabaseLogLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteDatabaseLogCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteDatabaseLogSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}