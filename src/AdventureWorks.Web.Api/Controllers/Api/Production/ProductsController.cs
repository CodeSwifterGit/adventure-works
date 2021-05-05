using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.Product.Commands.CreateProduct;
using AdventureWorks.Application.DataEngine.Production.Product.Commands.DeleteProduct;
using AdventureWorks.Application.DataEngine.Production.Product.Commands.UpdateProduct;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProductDetail;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productModelID}")]
        [ProducesResponseType(typeof(ProductsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductsListViewModel>> GetProductsByProductModel(
            int? productModelID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductsByProductModelListQuery()
            {
                ProductModelID = productModelID,
                DataTable = DataTableInfo<ProductSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productSubcategoryID}")]
        [ProducesResponseType(typeof(ProductsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductsListViewModel>> GetProductsByProductSubcategory(
            int? productSubcategoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductsByProductSubcategoryListQuery()
            {
                ProductSubcategoryID = productSubcategoryID,
                DataTable = DataTableInfo<ProductSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{sizeUnitMeasureCode}")]
        [ProducesResponseType(typeof(ProductsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductsListViewModel>> GetProductsByUnitMeasureSize(
            string sizeUnitMeasureCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductsByUnitMeasureListQuery()
            {
                SizeUnitMeasureCode = sizeUnitMeasureCode,
                DataTable = DataTableInfo<ProductSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{weightUnitMeasureCode}")]
        [ProducesResponseType(typeof(ProductsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductsListViewModel>> GetProductsByUnitMeasureWeight(
            string weightUnitMeasureCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductsByUnitMeasureListQuery()
            {
                WeightUnitMeasureCode = weightUnitMeasureCode,
                DataTable = DataTableInfo<ProductSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}")]
        [ProducesResponseType(typeof(ProductLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductLookupModel>> Get(int productID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductDetailQuery
            {
                ProductID = productID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProduct model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProduct> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}")]
        [ProducesResponseType(typeof(ProductLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, UpdateProductCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductCommand
            {
                ProductID = productID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}