using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.CreateProductProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.DeleteProductProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotoDetail;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductProductPhotosController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductProductPhotosListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductProductPhotosListViewModel>> GetProductProductPhotosByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductProductPhotosByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductProductPhotoSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productPhotoID}")]
        [ProducesResponseType(typeof(ProductProductPhotosListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductProductPhotosListViewModel>> GetProductProductPhotosByProductPhoto(
            int productPhotoID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductProductPhotosByProductPhotoListQuery()
            {
                ProductPhotoID = productPhotoID,
                DataTable = DataTableInfo<ProductProductPhotoSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}/{productPhotoID}")]
        [ProducesResponseType(typeof(ProductProductPhotoLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductProductPhotoLookupModel>> Get(int productID, int productPhotoID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductProductPhotoDetailQuery
            {
                ProductID = productID,
                ProductPhotoID = productPhotoID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductProductPhotoLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductProductPhoto model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductProductPhotoCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductProductPhotoLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductProductPhoto> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductProductPhotoSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}/{productPhotoID}")]
        [ProducesResponseType(typeof(ProductProductPhotoLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, int productPhotoID, UpdateProductProductPhotoCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductProductPhotoLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductProductPhotoCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductProductPhotoSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}/{productPhotoID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, int productPhotoID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductProductPhotoCommand
            {
                ProductID = productID,
                ProductPhotoID = productPhotoID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductProductPhotoLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductProductPhotoCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductProductPhotoSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}