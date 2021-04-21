using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.Document.Commands.CreateDocument;
using AdventureWorks.Application.DataEngine.Production.Document.Commands.DeleteDocument;
using AdventureWorks.Application.DataEngine.Production.Document.Commands.UpdateDocument;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocumentDetail;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class DocumentsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(DocumentsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DocumentsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDocumentsListQuery()
            {
                DataTable = DataTableInfo<DocumentSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{documentID}")]
        [ProducesResponseType(typeof(DocumentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DocumentLookupModel>> Get(int documentID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDocumentDetailQuery
            {
                DocumentID = documentID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(DocumentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseDocument model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateDocumentCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<DocumentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseDocument> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateDocumentSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{documentID}")]
        [ProducesResponseType(typeof(DocumentLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int documentID, UpdateDocumentCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<DocumentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateDocumentCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateDocumentSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{documentID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int documentID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteDocumentCommand
            {
                DocumentID = documentID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<DocumentLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteDocumentCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteDocumentSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}