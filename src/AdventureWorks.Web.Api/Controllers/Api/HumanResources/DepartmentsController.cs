using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.CreateDepartment;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.DeleteDepartment;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.UpdateDepartment;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartmentDetail;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class DepartmentsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(DepartmentsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DepartmentsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDepartmentsListQuery()
            {
                DataTable = DataTableInfo<DepartmentSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{departmentID}")]
        [ProducesResponseType(typeof(DepartmentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DepartmentLookupModel>> Get(short departmentID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDepartmentDetailQuery
            {
                DepartmentID = departmentID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(DepartmentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseDepartment model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateDepartmentCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<DepartmentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseDepartment> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateDepartmentSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{departmentID}")]
        [ProducesResponseType(typeof(DepartmentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(short departmentID, UpdateDepartmentCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<DepartmentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateDepartmentCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateDepartmentSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{departmentID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(short departmentID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteDepartmentCommand
            {
                DepartmentID = departmentID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<DepartmentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteDepartmentCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteDepartmentSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}