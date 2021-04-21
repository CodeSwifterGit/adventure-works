using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.CreateProductVendor;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.DeleteProductVendor;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.UpdateProductVendor;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendorDetail;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Purchasing
{
    public partial class ProductVendorsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductVendorsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVendorsListViewModel>> GetProductVendorsByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductVendorsByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductVendorSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{unitMeasureCode}")]
        [ProducesResponseType(typeof(ProductVendorsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVendorsListViewModel>> GetProductVendorsByUnitMeasure(
            string unitMeasureCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductVendorsByUnitMeasureListQuery()
            {
                UnitMeasureCode = unitMeasureCode,
                DataTable = DataTableInfo<ProductVendorSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{vendorID}")]
        [ProducesResponseType(typeof(ProductVendorsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVendorsListViewModel>> GetProductVendorsByVendor(
            int vendorID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductVendorsByVendorListQuery()
            {
                VendorID = vendorID,
                DataTable = DataTableInfo<ProductVendorSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}/{vendorID}")]
        [ProducesResponseType(typeof(ProductVendorLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVendorLookupModel>> Get(int productID, int vendorID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductVendorDetailQuery
            {
                ProductID = productID,
                VendorID = vendorID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductVendorLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductVendor model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductVendorCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductVendorLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductVendor> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductVendorSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}/{vendorID}")]
        [ProducesResponseType(typeof(ProductVendorLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, int vendorID, UpdateProductVendorCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductVendorLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductVendorCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductVendorSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}/{vendorID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, int vendorID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductVendorCommand
            {
                ProductID = productID,
                VendorID = vendorID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductVendorLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductVendorCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductVendorSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}