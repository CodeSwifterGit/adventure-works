using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.CreateProductModelIllustration;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.DeleteProductModelIllustration;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.UpdateProductModelIllustration;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrationDetail;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductModelIllustrationsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{illustrationID}")]
        [ProducesResponseType(typeof(ProductModelIllustrationsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelIllustrationsListViewModel>> GetProductModelIllustrationsByIllustration(
            int illustrationID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelIllustrationsByIllustrationListQuery()
            {
                IllustrationID = illustrationID,
                DataTable = DataTableInfo<ProductModelIllustrationSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productModelID}")]
        [ProducesResponseType(typeof(ProductModelIllustrationsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelIllustrationsListViewModel>> GetProductModelIllustrationsByProductModel(
            int productModelID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelIllustrationsByProductModelListQuery()
            {
                ProductModelID = productModelID,
                DataTable = DataTableInfo<ProductModelIllustrationSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productModelID}/{illustrationID}")]
        [ProducesResponseType(typeof(ProductModelIllustrationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelIllustrationLookupModel>> Get(int productModelID, int illustrationID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelIllustrationDetailQuery
            {
                ProductModelID = productModelID,
                IllustrationID = illustrationID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductModelIllustrationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductModelIllustration model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductModelIllustrationCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductModelIllustrationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductModelIllustration> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductModelIllustrationSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productModelID}/{illustrationID}")]
        [ProducesResponseType(typeof(ProductModelIllustrationLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productModelID, int illustrationID, UpdateProductModelIllustrationCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductModelIllustrationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductModelIllustrationCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductModelIllustrationSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productModelID}/{illustrationID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productModelID, int illustrationID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductModelIllustrationCommand
            {
                ProductModelID = productModelID,
                IllustrationID = illustrationID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductModelIllustrationLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductModelIllustrationCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductModelIllustrationSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}