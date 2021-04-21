using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.CreateSpecialOfferProduct;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.DeleteSpecialOfferProduct;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.UpdateSpecialOfferProduct;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProductDetail;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SpecialOfferProductsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(SpecialOfferProductsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SpecialOfferProductsListViewModel>> GetSpecialOfferProductsByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSpecialOfferProductsByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<SpecialOfferProductSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{specialOfferID}")]
        [ProducesResponseType(typeof(SpecialOfferProductsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SpecialOfferProductsListViewModel>> GetSpecialOfferProductsBySpecialOffer(
            int specialOfferID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSpecialOfferProductsBySpecialOfferListQuery()
            {
                SpecialOfferID = specialOfferID,
                DataTable = DataTableInfo<SpecialOfferProductSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{specialOfferID}/{productID}")]
        [ProducesResponseType(typeof(SpecialOfferProductLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SpecialOfferProductLookupModel>> Get(int specialOfferID, int productID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSpecialOfferProductDetailQuery
            {
                SpecialOfferID = specialOfferID,
                ProductID = productID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SpecialOfferProductLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSpecialOfferProduct model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSpecialOfferProductCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SpecialOfferProductLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSpecialOfferProduct> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSpecialOfferProductSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{specialOfferID}/{productID}")]
        [ProducesResponseType(typeof(SpecialOfferProductLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int specialOfferID, int productID, UpdateSpecialOfferProductCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SpecialOfferProductLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSpecialOfferProductCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSpecialOfferProductSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{specialOfferID}/{productID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int specialOfferID, int productID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSpecialOfferProductCommand
            {
                SpecialOfferID = specialOfferID,
                ProductID = productID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SpecialOfferProductLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSpecialOfferProductCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSpecialOfferProductSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}