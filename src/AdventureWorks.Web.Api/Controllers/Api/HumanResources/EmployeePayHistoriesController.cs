using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.CreateEmployeePayHistory;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.DeleteEmployeePayHistory;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.UpdateEmployeePayHistory;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistoryDetail;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class EmployeePayHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{employeeID}")]
        [ProducesResponseType(typeof(EmployeePayHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeePayHistoriesListViewModel>> GetEmployeePayHistoriesByEmployee(
            int employeeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeePayHistoriesByEmployeeListQuery()
            {
                EmployeeID = employeeID,
                DataTable = DataTableInfo<EmployeePayHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{employeeID}/{rateChangeDate}")]
        [ProducesResponseType(typeof(EmployeePayHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeePayHistoryLookupModel>> Get(int employeeID, DateTime rateChangeDate, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeePayHistoryDetailQuery
            {
                EmployeeID = employeeID,
                RateChangeDate = rateChangeDate
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeePayHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseEmployeePayHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeePayHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeePayHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseEmployeePayHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeePayHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{employeeID}/{rateChangeDate}")]
        [ProducesResponseType(typeof(EmployeePayHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int employeeID, DateTime rateChangeDate, UpdateEmployeePayHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<EmployeePayHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateEmployeePayHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateEmployeePayHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{employeeID}/{rateChangeDate}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int employeeID, DateTime rateChangeDate, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteEmployeePayHistoryCommand
            {
                EmployeeID = employeeID,
                RateChangeDate = rateChangeDate
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeePayHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteEmployeePayHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteEmployeePayHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}