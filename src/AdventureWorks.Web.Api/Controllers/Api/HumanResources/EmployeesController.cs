using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.CreateEmployee;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.DeleteEmployee;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.UpdateEmployee;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployeeDetail;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class EmployeesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactID}")]
        [ProducesResponseType(typeof(EmployeesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeesListViewModel>> GetEmployeesByContact(
            int contactID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeesByContactListQuery()
            {
                ContactID = contactID,
                DataTable = DataTableInfo<EmployeeSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{managerID}")]
        [ProducesResponseType(typeof(EmployeesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeesListViewModel>> GetEmployeesByEmployee(
            int? managerID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeesByEmployeeListQuery()
            {
                ManagerID = managerID,
                DataTable = DataTableInfo<EmployeeSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{employeeID}")]
        [ProducesResponseType(typeof(EmployeeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeLookupModel>> Get(int employeeID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeDetailQuery
            {
                EmployeeID = employeeID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseEmployee model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeeCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseEmployee> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeeSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{employeeID}")]
        [ProducesResponseType(typeof(EmployeeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int employeeID, UpdateEmployeeCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<EmployeeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateEmployeeCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateEmployeeSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{employeeID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int employeeID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteEmployeeCommand
            {
                EmployeeID = employeeID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteEmployeeCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteEmployeeSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}