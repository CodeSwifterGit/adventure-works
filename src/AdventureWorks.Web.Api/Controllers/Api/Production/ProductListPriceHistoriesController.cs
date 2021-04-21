using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.CreateProductListPriceHistory;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.DeleteProductListPriceHistory;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.UpdateProductListPriceHistory;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistoryDetail;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductListPriceHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductListPriceHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductListPriceHistoriesListViewModel>> GetProductListPriceHistoriesByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductListPriceHistoriesByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductListPriceHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}/{startDate}")]
        [ProducesResponseType(typeof(ProductListPriceHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductListPriceHistoryLookupModel>> Get(int productID, DateTime startDate, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductListPriceHistoryDetailQuery
            {
                ProductID = productID,
                StartDate = startDate
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductListPriceHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductListPriceHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductListPriceHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductListPriceHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductListPriceHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductListPriceHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}/{startDate}")]
        [ProducesResponseType(typeof(ProductListPriceHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, DateTime startDate, UpdateProductListPriceHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductListPriceHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductListPriceHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductListPriceHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}/{startDate}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, DateTime startDate, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductListPriceHistoryCommand
            {
                ProductID = productID,
                StartDate = startDate
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductListPriceHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductListPriceHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductListPriceHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}