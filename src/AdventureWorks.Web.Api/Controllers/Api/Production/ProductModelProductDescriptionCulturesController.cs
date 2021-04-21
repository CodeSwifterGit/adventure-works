using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.CreateProductModelProductDescriptionCulture;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.DeleteProductModelProductDescriptionCulture;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.UpdateProductModelProductDescriptionCulture;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultureDetail;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductModelProductDescriptionCulturesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{cultureID}")]
        [ProducesResponseType(typeof(ProductModelProductDescriptionCulturesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelProductDescriptionCulturesListViewModel>> GetProductModelProductDescriptionCulturesByCulture(
            string cultureID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelProductDescriptionCulturesByCultureListQuery()
            {
                CultureID = cultureID,
                DataTable = DataTableInfo<ProductModelProductDescriptionCultureSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productDescriptionID}")]
        [ProducesResponseType(typeof(ProductModelProductDescriptionCulturesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelProductDescriptionCulturesListViewModel>> GetProductModelProductDescriptionCulturesByProductDescription(
            int productDescriptionID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelProductDescriptionCulturesByProductDescriptionListQuery()
            {
                ProductDescriptionID = productDescriptionID,
                DataTable = DataTableInfo<ProductModelProductDescriptionCultureSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productModelID}")]
        [ProducesResponseType(typeof(ProductModelProductDescriptionCulturesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelProductDescriptionCulturesListViewModel>> GetProductModelProductDescriptionCulturesByProductModel(
            int productModelID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelProductDescriptionCulturesByProductModelListQuery()
            {
                ProductModelID = productModelID,
                DataTable = DataTableInfo<ProductModelProductDescriptionCultureSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productModelID}/{productDescriptionID}/{cultureID}")]
        [ProducesResponseType(typeof(ProductModelProductDescriptionCultureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelProductDescriptionCultureLookupModel>> Get(int productModelID, int productDescriptionID, string cultureID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelProductDescriptionCultureDetailQuery
            {
                ProductModelID = productModelID,
                ProductDescriptionID = productDescriptionID,
                CultureID = cultureID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductModelProductDescriptionCultureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductModelProductDescriptionCulture model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductModelProductDescriptionCultureCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductModelProductDescriptionCultureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductModelProductDescriptionCulture> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductModelProductDescriptionCultureSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productModelID}/{productDescriptionID}/{cultureID}")]
        [ProducesResponseType(typeof(ProductModelProductDescriptionCultureLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productModelID, int productDescriptionID, string cultureID, UpdateProductModelProductDescriptionCultureCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductModelProductDescriptionCultureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductModelProductDescriptionCultureCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductModelProductDescriptionCultureSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productModelID}/{productDescriptionID}/{cultureID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productModelID, int productDescriptionID, string cultureID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductModelProductDescriptionCultureCommand
            {
                ProductModelID = productModelID,
                ProductDescriptionID = productDescriptionID,
                CultureID = cultureID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductModelProductDescriptionCultureLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductModelProductDescriptionCultureCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductModelProductDescriptionCultureSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}