using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.CreateVendorAddress;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.DeleteVendorAddress;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.UpdateVendorAddress;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddressDetail;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class VendorAddressesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{addressID}")]
        [ProducesResponseType(typeof(VendorAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorAddressesListViewModel>> GetVendorAddressesByAddress(
            int addressID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorAddressesByAddressListQuery()
            {
                AddressID = addressID,
                DataTable = DataTableInfo<VendorAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{addressTypeID}")]
        [ProducesResponseType(typeof(VendorAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorAddressesListViewModel>> GetVendorAddressesByAddressType(
            int addressTypeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorAddressesByAddressTypeListQuery()
            {
                AddressTypeID = addressTypeID,
                DataTable = DataTableInfo<VendorAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{vendorID}")]
        [ProducesResponseType(typeof(VendorAddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorAddressesListViewModel>> GetVendorAddressesByVendor(
            int vendorID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorAddressesByVendorListQuery()
            {
                VendorID = vendorID,
                DataTable = DataTableInfo<VendorAddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{vendorID}/{addressID}")]
        [ProducesResponseType(typeof(VendorAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorAddressLookupModel>> Get(int vendorID, int addressID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorAddressDetailQuery
            {
                VendorID = vendorID,
                AddressID = addressID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(VendorAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseVendorAddress model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateVendorAddressCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<VendorAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseVendorAddress> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateVendorAddressSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{vendorID}/{addressID}")]
        [ProducesResponseType(typeof(VendorAddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int vendorID, int addressID, UpdateVendorAddressCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<VendorAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateVendorAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateVendorAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{vendorID}/{addressID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int vendorID, int addressID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteVendorAddressCommand
            {
                VendorID = vendorID,
                AddressID = addressID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<VendorAddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteVendorAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteVendorAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}