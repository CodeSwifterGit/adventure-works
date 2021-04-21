using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.CreateEmployeeAddress;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.DeleteEmployeeAddress;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.UpdateEmployeeAddress;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddressDetail;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class EmployeeAddressesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{addressID}")]
        [ProducesResponseType(typeof(EmployeeAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeAddressesListViewModel>> GetEmployeeAddressesByAddress(
            int addressID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeAddressesByAddressListQuery()
            {
                AddressID = addressID,
                DataTable = DataTableInfo<EmployeeAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{employeeID}")]
        [ProducesResponseType(typeof(EmployeeAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeAddressesListViewModel>> GetEmployeeAddressesByEmployee(
            int employeeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeAddressesByEmployeeListQuery()
            {
                EmployeeID = employeeID,
                DataTable = DataTableInfo<EmployeeAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{employeeID}/{addressID}")]
        [ProducesResponseType(typeof(EmployeeAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeAddressLookupModel>> Get(int employeeID, int addressID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetEmployeeAddressDetailQuery
            {
                EmployeeID = employeeID,
                AddressID = addressID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseEmployeeAddress model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeeAddressCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeeAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseEmployeeAddress> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateEmployeeAddressSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{employeeID}/{addressID}")]
        [ProducesResponseType(typeof(EmployeeAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int employeeID, int addressID, UpdateEmployeeAddressCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<EmployeeAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateEmployeeAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateEmployeeAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{employeeID}/{addressID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int employeeID, int addressID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteEmployeeAddressCommand
            {
                EmployeeID = employeeID,
                AddressID = addressID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<EmployeeAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteEmployeeAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteEmployeeAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}