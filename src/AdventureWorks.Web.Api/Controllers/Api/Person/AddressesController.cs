using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Person.Address.Commands.CreateAddress;
using AdventureWorks.Application.DataEngine.Person.Address.Commands.DeleteAddress;
using AdventureWorks.Application.DataEngine.Person.Address.Commands.UpdateAddress;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddressDetail;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Person
{
    public partial class AddressesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{stateProvinceID}")]
        [ProducesResponseType(typeof(AddressesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddressesListViewModel>> GetAddressesByStateProvince(
            int stateProvinceID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAddressesByStateProvinceListQuery()
            {
                StateProvinceID = stateProvinceID,
                DataTable = DataTableInfo<AddressSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{addressID}")]
        [ProducesResponseType(typeof(AddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddressLookupModel>> Get(int addressID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAddressDetailQuery
            {
                AddressID = addressID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(AddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseAddress model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateAddressCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<AddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseAddress> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateAddressSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{addressID}")]
        [ProducesResponseType(typeof(AddressLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int addressID, UpdateAddressCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<AddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{addressID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int addressID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteAddressCommand
            {
                AddressID = addressID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<AddressLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteAddressCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteAddressSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}