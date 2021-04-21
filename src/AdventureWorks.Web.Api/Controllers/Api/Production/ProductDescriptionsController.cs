using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.CreateProductDescription;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.DeleteProductDescription;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.UpdateProductDescription;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptionDetail;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductDescriptionsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ProductDescriptionsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDescriptionsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductDescriptionsListQuery()
            {
                DataTable = DataTableInfo<ProductDescriptionSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productDescriptionID}")]
        [ProducesResponseType(typeof(ProductDescriptionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDescriptionLookupModel>> Get(int productDescriptionID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductDescriptionDetailQuery
            {
                ProductDescriptionID = productDescriptionID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductDescriptionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductDescription model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductDescriptionCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductDescriptionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductDescription> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductDescriptionSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productDescriptionID}")]
        [ProducesResponseType(typeof(ProductDescriptionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productDescriptionID, UpdateProductDescriptionCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductDescriptionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductDescriptionCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductDescriptionSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productDescriptionID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productDescriptionID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductDescriptionCommand
            {
                ProductDescriptionID = productDescriptionID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductDescriptionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductDescriptionCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductDescriptionSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}