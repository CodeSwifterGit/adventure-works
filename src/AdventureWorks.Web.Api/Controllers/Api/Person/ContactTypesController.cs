using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Person.ContactType.Commands.CreateContactType;
using AdventureWorks.Application.DataEngine.Person.ContactType.Commands.DeleteContactType;
using AdventureWorks.Application.DataEngine.Person.ContactType.Commands.UpdateContactType;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypeDetail;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Person
{
    public partial class ContactTypesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ContactTypesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactTypesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactTypesListQuery()
            {
                DataTable = DataTableInfo<ContactTypeSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{contactTypeID}")]
        [ProducesResponseType(typeof(ContactTypeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactTypeLookupModel>> Get(int contactTypeID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactTypeDetailQuery
            {
                ContactTypeID = contactTypeID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ContactTypeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseContactType model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateContactTypeCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ContactTypeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseContactType> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateContactTypeSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{contactTypeID}")]
        [ProducesResponseType(typeof(ContactTypeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int contactTypeID, UpdateContactTypeCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ContactTypeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateContactTypeCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateContactTypeSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{contactTypeID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int contactTypeID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteContactTypeCommand
            {
                ContactTypeID = contactTypeID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ContactTypeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteContactTypeCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteContactTypeSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}