using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.CreateContactCreditCard;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.DeleteContactCreditCard;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.UpdateContactCreditCard;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCardDetail;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class ContactCreditCardsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactID}")]
        [ProducesResponseType(typeof(ContactCreditCardsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactCreditCardsListViewModel>> GetContactCreditCardsByContact(
            int contactID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactCreditCardsByContactListQuery()
            {
                ContactID = contactID,
                DataTable = DataTableInfo<ContactCreditCardSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{creditCardID}")]
        [ProducesResponseType(typeof(ContactCreditCardsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactCreditCardsListViewModel>> GetContactCreditCardsByCreditCard(
            int creditCardID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactCreditCardsByCreditCardListQuery()
            {
                CreditCardID = creditCardID,
                DataTable = DataTableInfo<ContactCreditCardSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{contactID}/{creditCardID}")]
        [ProducesResponseType(typeof(ContactCreditCardLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactCreditCardLookupModel>> Get(int contactID, int creditCardID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetContactCreditCardDetailQuery
            {
                ContactID = contactID,
                CreditCardID = creditCardID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ContactCreditCardLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseContactCreditCard model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateContactCreditCardCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ContactCreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseContactCreditCard> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateContactCreditCardSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{contactID}/{creditCardID}")]
        [ProducesResponseType(typeof(ContactCreditCardLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int contactID, int creditCardID, UpdateContactCreditCardCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ContactCreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateContactCreditCardCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateContactCreditCardSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{contactID}/{creditCardID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int contactID, int creditCardID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteContactCreditCardCommand
            {
                ContactID = contactID,
                CreditCardID = creditCardID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ContactCreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteContactCreditCardCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteContactCreditCardSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}