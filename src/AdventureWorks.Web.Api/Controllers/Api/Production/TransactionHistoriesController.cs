using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.CreateTransactionHistory;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.DeleteTransactionHistory;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.UpdateTransactionHistory;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistoryDetail;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class TransactionHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}")]
        [ProducesResponseType(typeof(TransactionHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransactionHistoriesListViewModel>> GetTransactionHistoriesByProduct(
            int productID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTransactionHistoriesByProductListQuery()
            {
                ProductID = productID,
                DataTable = DataTableInfo<TransactionHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{transactionID}")]
        [ProducesResponseType(typeof(TransactionHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransactionHistoryLookupModel>> Get(int transactionID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTransactionHistoryDetailQuery
            {
                TransactionID = transactionID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(TransactionHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseTransactionHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateTransactionHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<TransactionHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseTransactionHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateTransactionHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{transactionID}")]
        [ProducesResponseType(typeof(TransactionHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int transactionID, UpdateTransactionHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<TransactionHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateTransactionHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateTransactionHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{transactionID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int transactionID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteTransactionHistoryCommand
            {
                TransactionID = transactionID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<TransactionHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteTransactionHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteTransactionHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}