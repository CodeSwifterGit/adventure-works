using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.CreateSalesPerson;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.DeleteSalesPerson;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.UpdateSalesPerson;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPersonDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesPeopleController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesPersonID}")]
        [ProducesResponseType(typeof(SalesPeopleListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesPeopleListViewModel>> GetSalesPeopleByEmployee(
            int salesPersonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesPeopleByEmployeeListQuery()
            {
                SalesPersonID = salesPersonID,
                DataTable = DataTableInfo<SalesPersonSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{territoryID}")]
        [ProducesResponseType(typeof(SalesPeopleListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesPeopleListViewModel>> GetSalesPeopleBySalesTerritory(
            int? territoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesPeopleBySalesTerritoryListQuery()
            {
                TerritoryID = territoryID,
                DataTable = DataTableInfo<SalesPersonSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesPersonID}")]
        [ProducesResponseType(typeof(SalesPersonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesPersonLookupModel>> Get(int salesPersonID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesPersonDetailQuery
            {
                SalesPersonID = salesPersonID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesPersonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesPerson model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesPersonCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesPersonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesPerson> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesPersonSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesPersonID}")]
        [ProducesResponseType(typeof(SalesPersonLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesPersonID, UpdateSalesPersonCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesPersonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesPersonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesPersonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesPersonID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesPersonID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesPersonCommand
            {
                SalesPersonID = salesPersonID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesPersonLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesPersonCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesPersonSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}