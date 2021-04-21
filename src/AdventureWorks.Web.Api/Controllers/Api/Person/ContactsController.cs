using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Person.Contact.Commands.CreateContact;
using AdventureWorks.Application.DataEngine.Person.Contact.Commands.DeleteContact;
using AdventureWorks.Application.DataEngine.Person.Contact.Commands.UpdateContact;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContactDetail;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Person
{
    public partial class ContactsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ContactsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactsListQuery()
            {
                DataTable = DataTableInfo<ContactSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{contactID}")]
        [ProducesResponseType(typeof(ContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactLookupModel>> Get(int contactID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactDetailQuery
            {
                ContactID = contactID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseContact model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateContactCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseContact> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateContactSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{contactID}")]
        [ProducesResponseType(typeof(ContactLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int contactID, UpdateContactCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateContactCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateContactSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{contactID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int contactID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteContactCommand
            {
                ContactID = contactID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ContactLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteContactCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteContactSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}