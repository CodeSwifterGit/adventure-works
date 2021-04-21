using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.CreateCreditCard;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.DeleteCreditCard;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.UpdateCreditCard;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCardDetail;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class CreditCardsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(CreditCardsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreditCardsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCreditCardsListQuery()
            {
                DataTable = DataTableInfo<CreditCardSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{creditCardID}")]
        [ProducesResponseType(typeof(CreditCardLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreditCardLookupModel>> Get(int creditCardID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCreditCardDetailQuery
            {
                CreditCardID = creditCardID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CreditCardLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCreditCard model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCreditCardCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCreditCard> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCreditCardSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{creditCardID}")]
        [ProducesResponseType(typeof(CreditCardLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int creditCardID, UpdateCreditCardCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCreditCardCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCreditCardSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{creditCardID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int creditCardID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCreditCardCommand
            {
                CreditCardID = creditCardID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCreditCardCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCreditCardSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}