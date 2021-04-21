using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.CreateVendorContact;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.DeleteVendorContact;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.UpdateVendorContact;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContactDetail;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class VendorContactsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactID}")]
        [ProducesResponseType(typeof(VendorContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorContactsListViewModel>> GetVendorContactsByContact(
            int contactID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorContactsByContactListQuery()
            {
                ContactID = contactID,
                DataTable = DataTableInfo<VendorContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactTypeID}")]
        [ProducesResponseType(typeof(VendorContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorContactsListViewModel>> GetVendorContactsByContactType(
            int contactTypeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorContactsByContactTypeListQuery()
            {
                ContactTypeID = contactTypeID,
                DataTable = DataTableInfo<VendorContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{vendorID}")]
        [ProducesResponseType(typeof(VendorContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorContactsListViewModel>> GetVendorContactsByVendor(
            int vendorID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorContactsByVendorListQuery()
            {
                VendorID = vendorID,
                DataTable = DataTableInfo<VendorContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{vendorID}/{contactID}")]
        [ProducesResponseType(typeof(VendorContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorContactLookupModel>> Get(int vendorID, int contactID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorContactDetailQuery
            {
                VendorID = vendorID,
                ContactID = contactID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(VendorContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseVendorContact model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateVendorContactCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<VendorContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseVendorContact> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateVendorContactSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{vendorID}/{contactID}")]
        [ProducesResponseType(typeof(VendorContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int vendorID, int contactID, UpdateVendorContactCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<VendorContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateVendorContactCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateVendorContactSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{vendorID}/{contactID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int vendorID, int contactID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteVendorContactCommand
            {
                VendorID = vendorID,
                ContactID = contactID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<VendorContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteVendorContactCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteVendorContactSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}