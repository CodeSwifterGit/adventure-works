using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.CreateSpecialOffer;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.DeleteSpecialOffer;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.UpdateSpecialOffer;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOfferDetail;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SpecialOffersController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(SpecialOffersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SpecialOffersListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSpecialOffersListQuery()
            {
                DataTable = DataTableInfo<SpecialOfferSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{specialOfferID}")]
        [ProducesResponseType(typeof(SpecialOfferLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SpecialOfferLookupModel>> Get(int specialOfferID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSpecialOfferDetailQuery
            {
                SpecialOfferID = specialOfferID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SpecialOfferLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSpecialOffer model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSpecialOfferCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SpecialOfferLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSpecialOffer> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSpecialOfferSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{specialOfferID}")]
        [ProducesResponseType(typeof(SpecialOfferLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int specialOfferID, UpdateSpecialOfferCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SpecialOfferLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSpecialOfferCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSpecialOfferSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{specialOfferID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int specialOfferID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSpecialOfferCommand
            {
                SpecialOfferID = specialOfferID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SpecialOfferLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSpecialOfferCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSpecialOfferSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}