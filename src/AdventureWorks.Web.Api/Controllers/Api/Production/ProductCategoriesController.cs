using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.CreateProductCategory;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.DeleteProductCategory;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.UpdateProductCategory;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategoryDetail;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductCategoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ProductCategoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductCategoriesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductCategoriesListQuery()
            {
                DataTable = DataTableInfo<ProductCategorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productCategoryID}")]
        [ProducesResponseType(typeof(ProductCategoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductCategoryLookupModel>> Get(int productCategoryID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductCategoryDetailQuery
            {
                ProductCategoryID = productCategoryID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductCategoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductCategory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductCategoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductCategoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductCategory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductCategorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productCategoryID}")]
        [ProducesResponseType(typeof(ProductCategoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productCategoryID, UpdateProductCategoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductCategoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductCategoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductCategorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productCategoryID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productCategoryID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductCategoryCommand
            {
                ProductCategoryID = productCategoryID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductCategoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductCategoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductCategorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}