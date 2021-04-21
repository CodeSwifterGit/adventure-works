using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.CreateEmployeeDepartmentHistory;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.DeleteEmployeeDepartmentHistory;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistoryDetail;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class EmployeeDepartmentHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{departmentID}")]
        [ProducesResponseType(typeof(EmployeeDepartmentHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeDepartmentHistoriesListViewModel>> GetEmployeeDepartmentHistoriesByDepartment(
            short departmentID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeDepartmentHistoriesByDepartmentListQuery()
            {
                DepartmentID = departmentID,
                DataTable = DataTableInfo<EmployeeDepartmentHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{employeeID}")]
        [ProducesResponseType(typeof(EmployeeDepartmentHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeDepartmentHistoriesListViewModel>> GetEmployeeDepartmentHistoriesByEmployee(
            int employeeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeDepartmentHistoriesByEmployeeListQuery()
            {
                EmployeeID = employeeID,
                DataTable = DataTableInfo<EmployeeDepartmentHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{shiftID}")]
        [ProducesResponseType(typeof(EmployeeDepartmentHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeDepartmentHistoriesListViewModel>> GetEmployeeDepartmentHistoriesByShift(
            byte shiftID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeDepartmentHistoriesByShiftListQuery()
            {
                ShiftID = shiftID,
                DataTable = DataTableInfo<EmployeeDepartmentHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{employeeID}/{departmentID}/{shiftID}/{startDate}")]
        [ProducesResponseType(typeof(EmployeeDepartmentHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeDepartmentHistoryLookupModel>> Get(int employeeID, short departmentID, byte shiftID, DateTime startDate, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeDepartmentHistoryDetailQuery
            {
                EmployeeID = employeeID,
                DepartmentID = departmentID,
                ShiftID = shiftID,
                StartDate = startDate
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDepartmentHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseEmployeeDepartmentHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeeDepartmentHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeeDepartmentHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseEmployeeDepartmentHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeeDepartmentHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{employeeID}/{departmentID}/{shiftID}/{startDate}")]
        [ProducesResponseType(typeof(EmployeeDepartmentHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int employeeID, short departmentID, byte shiftID, DateTime startDate, UpdateEmployeeDepartmentHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<EmployeeDepartmentHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateEmployeeDepartmentHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateEmployeeDepartmentHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{employeeID}/{departmentID}/{shiftID}/{startDate}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int employeeID, short departmentID, byte shiftID, DateTime startDate, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteEmployeeDepartmentHistoryCommand
            {
                EmployeeID = employeeID,
                DepartmentID = departmentID,
                ShiftID = shiftID,
                StartDate = startDate
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeeDepartmentHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteEmployeeDepartmentHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteEmployeeDepartmentHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}