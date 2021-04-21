using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.CreateProductInventory;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.DeleteProductInventory;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.UpdateProductInventory;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventoryDetail;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductInventoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{locationID}")]
        [ProducesResponseType(typeof(ProductInventoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductInventoriesListViewModel>> GetProductInventoriesByLocation(
            short locationID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductInventoriesByLocationListQuery()
            {
                LocationID = locationID,
                DataTable = DataTableInfo<ProductInventorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductInventoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductInventoriesListViewModel>> GetProductInventoriesByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductInventoriesByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductInventorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}/{locationID}")]
        [ProducesResponseType(typeof(ProductInventoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductInventoryLookupModel>> Get(int productID, short locationID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductInventoryDetailQuery
            {
                ProductID = productID,
                LocationID = locationID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductInventoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductInventory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductInventoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductInventoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductInventory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductInventorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}/{locationID}")]
        [ProducesResponseType(typeof(ProductInventoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, short locationID, UpdateProductInventoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductInventoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductInventoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductInventorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}/{locationID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, short locationID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductInventoryCommand
            {
                ProductID = productID,
                LocationID = locationID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductInventoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductInventoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductInventorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}