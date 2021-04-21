using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.Individual.Commands.CreateIndividual;
using AdventureWorks.Application.DataEngine.Sales.Individual.Commands.DeleteIndividual;
using AdventureWorks.Application.DataEngine.Sales.Individual.Commands.UpdateIndividual;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividualDetail;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class IndividualsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactID}")]
        [ProducesResponseType(typeof(IndividualsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndividualsListViewModel>> GetIndividualsByContact(
            int contactID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetIndividualsByContactListQuery()
            {
                ContactID = contactID,
                DataTable = DataTableInfo<IndividualSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{customerID}")]
        [ProducesResponseType(typeof(IndividualsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndividualsListViewModel>> GetIndividualsByCustomer(
            int customerID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetIndividualsByCustomerListQuery()
            {
                CustomerID = customerID,
                DataTable = DataTableInfo<IndividualSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{customerID}")]
        [ProducesResponseType(typeof(IndividualLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IndividualLookupModel>> Get(int customerID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetIndividualDetailQuery
            {
                CustomerID = customerID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(IndividualLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseIndividual model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateIndividualCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<IndividualLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseIndividual> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateIndividualSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{customerID}")]
        [ProducesResponseType(typeof(IndividualLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int customerID, UpdateIndividualCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<IndividualLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateIndividualCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateIndividualSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{customerID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int customerID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteIndividualCommand
            {
                CustomerID = customerID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<IndividualLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteIndividualCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteIndividualSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}