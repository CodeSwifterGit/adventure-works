using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.CreateTransactionHistoryArchive;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.DeleteTransactionHistoryArchive;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.UpdateTransactionHistoryArchive;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchiveDetail;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class TransactionHistoryArchivesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(TransactionHistoryArchivesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransactionHistoryArchivesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTransactionHistoryArchivesListQuery()
            {
                DataTable = DataTableInfo<TransactionHistoryArchiveSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{transactionID}")]
        [ProducesResponseType(typeof(TransactionHistoryArchiveLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransactionHistoryArchiveLookupModel>> Get(int transactionID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTransactionHistoryArchiveDetailQuery
            {
                TransactionID = transactionID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(TransactionHistoryArchiveLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseTransactionHistoryArchive model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateTransactionHistoryArchiveCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<TransactionHistoryArchiveLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseTransactionHistoryArchive> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateTransactionHistoryArchiveSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{transactionID}")]
        [ProducesResponseType(typeof(TransactionHistoryArchiveLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int transactionID, UpdateTransactionHistoryArchiveCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<TransactionHistoryArchiveLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateTransactionHistoryArchiveCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateTransactionHistoryArchiveSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{transactionID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int transactionID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteTransactionHistoryArchiveCommand
            {
                TransactionID = transactionID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<TransactionHistoryArchiveLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteTransactionHistoryArchiveCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteTransactionHistoryArchiveSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}