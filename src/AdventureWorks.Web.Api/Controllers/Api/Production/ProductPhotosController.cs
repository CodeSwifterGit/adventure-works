using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.CreateProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.DeleteProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.UpdateProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotoDetail;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductPhotosController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(ProductPhotosListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductPhotosListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductPhotosListQuery()
            {
                DataTable = DataTableInfo<ProductPhotoSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productPhotoID}")]
        [ProducesResponseType(typeof(ProductPhotoLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductPhotoLookupModel>> Get(int productPhotoID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductPhotoDetailQuery
            {
                ProductPhotoID = productPhotoID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductPhotoLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductPhoto model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductPhotoCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductPhotoLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductPhoto> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductPhotoSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productPhotoID}")]
        [ProducesResponseType(typeof(ProductPhotoLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productPhotoID, UpdateProductPhotoCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductPhotoLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductPhotoCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductPhotoSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productPhotoID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productPhotoID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductPhotoCommand
            {
                ProductPhotoID = productPhotoID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductPhotoLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductPhotoCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductPhotoSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}