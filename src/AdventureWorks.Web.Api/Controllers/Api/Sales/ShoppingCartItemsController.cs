using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.CreateShoppingCartItem;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.DeleteShoppingCartItem;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.UpdateShoppingCartItem;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItemDetail;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class ShoppingCartItemsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ShoppingCartItemsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartItemsListViewModel>> GetShoppingCartItemsByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetShoppingCartItemsByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ShoppingCartItemSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{shoppingCartItemID}")]
        [ProducesResponseType(typeof(ShoppingCartItemLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartItemLookupModel>> Get(int shoppingCartItemID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetShoppingCartItemDetailQuery
            {
                ShoppingCartItemID = shoppingCartItemID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCartItemLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseShoppingCartItem model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateShoppingCartItemCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ShoppingCartItemLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseShoppingCartItem> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateShoppingCartItemSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{shoppingCartItemID}")]
        [ProducesResponseType(typeof(ShoppingCartItemLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int shoppingCartItemID, UpdateShoppingCartItemCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ShoppingCartItemLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateShoppingCartItemCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateShoppingCartItemSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{shoppingCartItemID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int shoppingCartItemID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteShoppingCartItemCommand
            {
                ShoppingCartItemID = shoppingCartItemID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ShoppingCartItemLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteShoppingCartItemCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteShoppingCartItemSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}