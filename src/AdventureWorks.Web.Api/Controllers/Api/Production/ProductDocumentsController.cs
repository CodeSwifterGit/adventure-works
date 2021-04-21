using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.CreateProductDocument;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.DeleteProductDocument;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.UpdateProductDocument;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocumentDetail;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class ProductDocumentsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{documentID}")]
        [ProducesResponseType(typeof(ProductDocumentsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDocumentsListViewModel>> GetProductDocumentsByDocument(
            int documentID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductDocumentsByDocumentListQuery()
            {
                DocumentID = documentID,
                DataTable = DataTableInfo<ProductDocumentSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(ProductDocumentsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDocumentsListViewModel>> GetProductDocumentsByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductDocumentsByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<ProductDocumentSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{productID}/{documentID}")]
        [ProducesResponseType(typeof(ProductDocumentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDocumentLookupModel>> Get(int productID, int documentID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductDocumentDetailQuery
            {
                ProductID = productID,
                DocumentID = documentID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(ProductDocumentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseProductDocument model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductDocumentCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductDocumentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseProductDocument> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateProductDocumentSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{productID}/{documentID}")]
        [ProducesResponseType(typeof(ProductDocumentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productID, int documentID, UpdateProductDocumentCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<ProductDocumentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateProductDocumentCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateProductDocumentSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{productID}/{documentID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int productID, int documentID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProductDocumentCommand
            {
                ProductID = productID,
                DocumentID = documentID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<ProductDocumentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteProductDocumentCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteProductDocumentSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}