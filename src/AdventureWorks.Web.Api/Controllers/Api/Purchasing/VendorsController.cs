using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.CreateVendor;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.DeleteVendor;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.UpdateVendor;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendorDetail;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class VendorsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(VendorsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorsListQuery()
            {
                DataTable = DataTableInfo<VendorSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{vendorID}")]
        [ProducesResponseType(typeof(VendorLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VendorLookupModel>> Get(int vendorID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVendorDetailQuery
            {
                VendorID = vendorID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(VendorLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseVendor model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateVendorCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<VendorLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseVendor> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateVendorSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{vendorID}")]
        [ProducesResponseType(typeof(VendorLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int vendorID, UpdateVendorCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<VendorLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateVendorCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateVendorSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{vendorID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int vendorID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteVendorCommand
            {
                VendorID = vendorID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<VendorLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteVendorCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteVendorSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}