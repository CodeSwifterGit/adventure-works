using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.CreateCustomerAddress;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.DeleteCustomerAddress;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.UpdateCustomerAddress;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddressDetail;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class CustomerAddressesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{addressID}")]
        [ProducesResponseType(typeof(CustomerAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerAddressesListViewModel>> GetCustomerAddressesByAddress(
            int addressID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerAddressesByAddressListQuery()
            {
                AddressID = addressID,
                DataTable = DataTableInfo<CustomerAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{addressTypeID}")]
        [ProducesResponseType(typeof(CustomerAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerAddressesListViewModel>> GetCustomerAddressesByAddressType(
            int addressTypeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerAddressesByAddressTypeListQuery()
            {
                AddressTypeID = addressTypeID,
                DataTable = DataTableInfo<CustomerAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{customerID}")]
        [ProducesResponseType(typeof(CustomerAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerAddressesListViewModel>> GetCustomerAddressesByCustomer(
            int customerID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerAddressesByCustomerListQuery()
            {
                CustomerID = customerID,
                DataTable = DataTableInfo<CustomerAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{customerID}/{addressID}")]
        [ProducesResponseType(typeof(CustomerAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerAddressLookupModel>> Get(int customerID, int addressID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerAddressDetailQuery
            {
                CustomerID = customerID,
                AddressID = addressID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCustomerAddress model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCustomerAddressCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CustomerAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCustomerAddress> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCustomerAddressSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{customerID}/{addressID}")]
        [ProducesResponseType(typeof(CustomerAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int customerID, int addressID, UpdateCustomerAddressCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CustomerAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCustomerAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCustomerAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{customerID}/{addressID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int customerID, int addressID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCustomerAddressCommand
            {
                CustomerID = customerID,
                AddressID = addressID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CustomerAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCustomerAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCustomerAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}