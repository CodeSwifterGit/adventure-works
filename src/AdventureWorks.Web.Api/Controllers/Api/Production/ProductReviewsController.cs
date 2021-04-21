using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.CreateProductReview;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.DeleteProductReview;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.UpdateProductReview;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviewDetail;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductReviewsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductReviewsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductReviewsListViewModel>> GetProductReviewsByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductReviewsByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductReviewSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productReviewID}")]
        [ProducesResponseType(typeof(ProductReviewLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductReviewLookupModel>> Get(int productReviewID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductReviewDetailQuery
            {
                ProductReviewID = productReviewID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductReviewLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductReview model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductReviewCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductReviewLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductReview> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductReviewSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productReviewID}")]
        [ProducesResponseType(typeof(ProductReviewLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productReviewID, UpdateProductReviewCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductReviewLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductReviewCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductReviewSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productReviewID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productReviewID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductReviewCommand
            {
                ProductReviewID = productReviewID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductReviewLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductReviewCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductReviewSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}