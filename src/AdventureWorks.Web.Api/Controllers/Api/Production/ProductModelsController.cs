using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.CreateProductModel;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.DeleteProductModel;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.UpdateProductModel;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModelDetail;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductModelsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ProductModelsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelsListQuery()
            {
                DataTable = DataTableInfo<ProductModelSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productModelID}")]
        [ProducesResponseType(typeof(ProductModelLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModelLookupModel>> Get(int productModelID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductModelDetailQuery
            {
                ProductModelID = productModelID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductModelLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductModel model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductModelCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductModelLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductModel> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductModelSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productModelID}")]
        [ProducesResponseType(typeof(ProductModelLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productModelID, UpdateProductModelCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductModelLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductModelCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductModelSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productModelID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productModelID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductModelCommand
            {
                ProductModelID = productModelID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductModelLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductModelCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductModelSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}