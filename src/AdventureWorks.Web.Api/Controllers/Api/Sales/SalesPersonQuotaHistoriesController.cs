using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.CreateSalesPersonQuotaHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.DeleteSalesPersonQuotaHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.UpdateSalesPersonQuotaHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistoryDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesPersonQuotaHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesPersonID}")]
        [ProducesResponseType(typeof(SalesPersonQuotaHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesPersonQuotaHistoriesListViewModel>> GetSalesPersonQuotaHistoriesBySalesPerson(
            int salesPersonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesPersonQuotaHistoriesBySalesPersonListQuery()
            {
                SalesPersonID = salesPersonID,
                DataTable = DataTableInfo<SalesPersonQuotaHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesPersonID}/{quotaDate}")]
        [ProducesResponseType(typeof(SalesPersonQuotaHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesPersonQuotaHistoryLookupModel>> Get(int salesPersonID, DateTime quotaDate, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesPersonQuotaHistoryDetailQuery
            {
                SalesPersonID = salesPersonID,
                QuotaDate = quotaDate
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesPersonQuotaHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesPersonQuotaHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesPersonQuotaHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesPersonQuotaHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesPersonQuotaHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesPersonQuotaHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesPersonID}/{quotaDate}")]
        [ProducesResponseType(typeof(SalesPersonQuotaHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesPersonID, DateTime quotaDate, UpdateSalesPersonQuotaHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesPersonQuotaHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesPersonQuotaHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesPersonQuotaHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesPersonID}/{quotaDate}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesPersonID, DateTime quotaDate, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesPersonQuotaHistoryCommand
            {
                SalesPersonID = salesPersonID,
                QuotaDate = quotaDate
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesPersonQuotaHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesPersonQuotaHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesPersonQuotaHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}