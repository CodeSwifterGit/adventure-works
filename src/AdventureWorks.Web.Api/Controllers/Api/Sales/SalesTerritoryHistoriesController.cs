using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.CreateSalesTerritoryHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.DeleteSalesTerritoryHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.UpdateSalesTerritoryHistory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistoryDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesTerritoryHistoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesPersonID}")]
        [ProducesResponseType(typeof(SalesTerritoryHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTerritoryHistoriesListViewModel>> GetSalesTerritoryHistoriesBySalesPerson(
            int salesPersonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTerritoryHistoriesBySalesPersonListQuery()
            {
                SalesPersonID = salesPersonID,
                DataTable = DataTableInfo<SalesTerritoryHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{territoryID}")]
        [ProducesResponseType(typeof(SalesTerritoryHistoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTerritoryHistoriesListViewModel>> GetSalesTerritoryHistoriesBySalesTerritory(
            int territoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTerritoryHistoriesBySalesTerritoryListQuery()
            {
                TerritoryID = territoryID,
                DataTable = DataTableInfo<SalesTerritoryHistorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesPersonID}/{territoryID}/{startDate}")]
        [ProducesResponseType(typeof(SalesTerritoryHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTerritoryHistoryLookupModel>> Get(int salesPersonID, int territoryID, DateTime startDate, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTerritoryHistoryDetailQuery
            {
                SalesPersonID = salesPersonID,
                TerritoryID = territoryID,
                StartDate = startDate
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesTerritoryHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesTerritoryHistory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesTerritoryHistoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesTerritoryHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesTerritoryHistory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesTerritoryHistorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesPersonID}/{territoryID}/{startDate}")]
        [ProducesResponseType(typeof(SalesTerritoryHistoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesPersonID, int territoryID, DateTime startDate, UpdateSalesTerritoryHistoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesTerritoryHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesTerritoryHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesTerritoryHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesPersonID}/{territoryID}/{startDate}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesPersonID, int territoryID, DateTime startDate, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesTerritoryHistoryCommand
            {
                SalesPersonID = salesPersonID,
                TerritoryID = territoryID,
                StartDate = startDate
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesTerritoryHistoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesTerritoryHistoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesTerritoryHistorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}