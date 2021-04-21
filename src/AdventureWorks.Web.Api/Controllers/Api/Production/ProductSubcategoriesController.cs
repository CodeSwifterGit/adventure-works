using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.CreateProductSubcategory;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.DeleteProductSubcategory;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.UpdateProductSubcategory;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategoryDetail;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductSubcategoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productCategoryID}")]
        [ProducesResponseType(typeof(ProductSubcategoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductSubcategoriesListViewModel>> GetProductSubcategoriesByProductCategory(
            int productCategoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductSubcategoriesByProductCategoryListQuery()
            {
                ProductCategoryID = productCategoryID,
                DataTable = DataTableInfo<ProductSubcategorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productSubcategoryID}")]
        [ProducesResponseType(typeof(ProductSubcategoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductSubcategoryLookupModel>> Get(int productSubcategoryID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductSubcategoryDetailQuery
            {
                ProductSubcategoryID = productSubcategoryID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductSubcategoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductSubcategory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductSubcategoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductSubcategoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductSubcategory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductSubcategorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productSubcategoryID}")]
        [ProducesResponseType(typeof(ProductSubcategoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productSubcategoryID, UpdateProductSubcategoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductSubcategoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductSubcategoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductSubcategorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productSubcategoryID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productSubcategoryID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductSubcategoryCommand
            {
                ProductSubcategoryID = productSubcategoryID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductSubcategoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductSubcategoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductSubcategorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}