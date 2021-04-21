using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.CreateProductCostHistory;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.DeleteProductCostHistory;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.UpdateProductCostHistory;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistoryDetail;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductCostHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductCostHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductCostHistoriesListViewModel>> GetProductCostHistoriesByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductCostHistoriesByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductCostHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}/{startDate}")]
        [ProducesResponseType(typeof(ProductCostHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductCostHistoryLookupModel>> Get(int productID, DateTime startDate, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductCostHistoryDetailQuery
            {
                ProductID = productID,
                StartDate = startDate
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductCostHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductCostHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductCostHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductCostHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductCostHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductCostHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}/{startDate}")]
        [ProducesResponseType(typeof(ProductCostHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, DateTime startDate, UpdateProductCostHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductCostHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductCostHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductCostHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}/{startDate}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, DateTime startDate, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductCostHistoryCommand
            {
                ProductID = productID,
                StartDate = startDate
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductCostHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductCostHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductCostHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}