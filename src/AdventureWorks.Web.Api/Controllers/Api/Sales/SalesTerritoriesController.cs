using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.CreateSalesTerritory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.DeleteSalesTerritory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.UpdateSalesTerritory;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritoryDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesTerritoriesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(SalesTerritoriesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTerritoriesListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTerritoriesListQuery()
            {
                DataTable = DataTableInfo<SalesTerritorySummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{territoryID}")]
        [ProducesResponseType(typeof(SalesTerritoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesTerritoryLookupModel>> Get(int territoryID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesTerritoryDetailQuery
            {
                TerritoryID = territoryID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesTerritoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesTerritory model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesTerritoryCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesTerritoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesTerritory> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesTerritorySetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{territoryID}")]
        [ProducesResponseType(typeof(SalesTerritoryLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int territoryID, UpdateSalesTerritoryCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesTerritoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesTerritoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesTerritorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{territoryID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int territoryID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesTerritoryCommand
            {
                TerritoryID = territoryID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesTerritoryLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesTerritoryCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesTerritorySetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}