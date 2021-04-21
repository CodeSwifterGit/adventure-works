using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.CreateStoreContact;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.DeleteStoreContact;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.UpdateStoreContact;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContactDetail;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class StoreContactsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactID}")]
        [ProducesResponseType(typeof(StoreContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoreContactsListViewModel>> GetStoreContactsByContact(
            int contactID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoreContactsByContactListQuery()
            {
                ContactID = contactID,
                DataTable = DataTableInfo<StoreContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactTypeID}")]
        [ProducesResponseType(typeof(StoreContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoreContactsListViewModel>> GetStoreContactsByContactType(
            int contactTypeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoreContactsByContactTypeListQuery()
            {
                ContactTypeID = contactTypeID,
                DataTable = DataTableInfo<StoreContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{customerID}")]
        [ProducesResponseType(typeof(StoreContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoreContactsListViewModel>> GetStoreContactsByStore(
            int customerID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoreContactsByStoreListQuery()
            {
                CustomerID = customerID,
                DataTable = DataTableInfo<StoreContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{customerID}/{contactID}")]
        [ProducesResponseType(typeof(StoreContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoreContactLookupModel>> Get(int customerID, int contactID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoreContactDetailQuery
            {
                CustomerID = customerID,
                ContactID = contactID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(StoreContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseStoreContact model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStoreContactCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<StoreContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseStoreContact> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStoreContactSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{customerID}/{contactID}")]
        [ProducesResponseType(typeof(StoreContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int customerID, int contactID, UpdateStoreContactCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<StoreContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateStoreContactCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateStoreContactSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{customerID}/{contactID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int customerID, int contactID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteStoreContactCommand
            {
                CustomerID = customerID,
                ContactID = contactID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<StoreContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteStoreContactCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteStoreContactSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}