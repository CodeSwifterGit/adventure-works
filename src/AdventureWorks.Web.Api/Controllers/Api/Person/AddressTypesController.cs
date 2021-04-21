using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Person.AddressType.Commands.CreateAddressType;
using AdventureWorks.Application.DataEngine.Person.AddressType.Commands.DeleteAddressType;
using AdventureWorks.Application.DataEngine.Person.AddressType.Commands.UpdateAddressType;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypeDetail;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Person
{
    public partial class AddressTypesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(AddressTypesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddressTypesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAddressTypesListQuery()
            {
                DataTable = DataTableInfo<AddressTypeSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{addressTypeID}")]
        [ProducesResponseType(typeof(AddressTypeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddressTypeLookupModel>> Get(int addressTypeID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAddressTypeDetailQuery
            {
                AddressTypeID = addressTypeID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(AddressTypeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseAddressType model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateAddressTypeCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<AddressTypeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseAddressType> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateAddressTypeSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{addressTypeID}")]
        [ProducesResponseType(typeof(AddressTypeLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int addressTypeID, UpdateAddressTypeCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<AddressTypeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateAddressTypeCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateAddressTypeSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{addressTypeID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int addressTypeID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteAddressTypeCommand
            {
                AddressTypeID = addressTypeID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<AddressTypeLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteAddressTypeCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteAddressTypeSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}