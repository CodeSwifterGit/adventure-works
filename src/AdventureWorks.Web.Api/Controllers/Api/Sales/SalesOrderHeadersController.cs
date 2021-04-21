using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.CreateSalesOrderHeader;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.DeleteSalesOrderHeader;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.UpdateSalesOrderHeader;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaderDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesOrderHeadersController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{billToAddressID}/{shipToAddressID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersByAddress(
            int billToAddressID, int shipToAddressID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersByAddressListQuery()
            {
                BillToAddressID = billToAddressID,
                ShipToAddressID = shipToAddressID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{contactID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersByContact(
            int contactID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersByContactListQuery()
            {
                ContactID = contactID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{creditCardID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersByCreditCard(
            int? creditCardID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersByCreditCardListQuery()
            {
                CreditCardID = creditCardID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{currencyRateID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersByCurrencyRate(
            int? currencyRateID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersByCurrencyRateListQuery()
            {
                CurrencyRateID = currencyRateID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{customerID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersByCustomer(
            int customerID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersByCustomerListQuery()
            {
                CustomerID = customerID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesPersonID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersBySalesPerson(
            int? salesPersonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersBySalesPersonListQuery()
            {
                SalesPersonID = salesPersonID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{territoryID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersBySalesTerritory(
            int? territoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersBySalesTerritoryListQuery()
            {
                TerritoryID = territoryID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{shipMethodID}")]
        [ProducesResponseType(typeof(SalesOrderHeadersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeadersListViewModel>> GetSalesOrderHeadersByShipMethod(
            int shipMethodID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeadersByShipMethodListQuery()
            {
                ShipMethodID = shipMethodID,
                DataTable = DataTableInfo<SalesOrderHeaderSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesOrderID}")]
        [ProducesResponseType(typeof(SalesOrderHeaderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderHeaderLookupModel>> Get(int salesOrderID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderHeaderDetailQuery
            {
                SalesOrderID = salesOrderID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesOrderHeaderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesOrderHeader model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesOrderHeaderCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderHeaderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesOrderHeader> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesOrderHeaderSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesOrderID}")]
        [ProducesResponseType(typeof(SalesOrderHeaderLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesOrderID, UpdateSalesOrderHeaderCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderHeaderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesOrderHeaderCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesOrderHeaderSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesOrderID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesOrderID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesOrderHeaderCommand
            {
                SalesOrderID = salesOrderID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderHeaderLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesOrderHeaderCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesOrderHeaderSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}