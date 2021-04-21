using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.CreateSalesOrderDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.DeleteSalesOrderDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.UpdateSalesOrderDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetailDetail;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class SalesOrderDetailsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesOrderID}")]
        [ProducesResponseType(typeof(SalesOrderDetailsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderDetailsListViewModel>> GetSalesOrderDetailsBySalesOrderHeader(
            int salesOrderID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderDetailsBySalesOrderHeaderListQuery()
            {
                SalesOrderID = salesOrderID,
                DataTable = DataTableInfo<SalesOrderDetailSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productID}/{specialOfferID}")]
        [ProducesResponseType(typeof(SalesOrderDetailsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderDetailsListViewModel>> GetSalesOrderDetailsBySpecialOfferProduct(
            int productID, int specialOfferID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderDetailsBySpecialOfferProductListQuery()
            {
                ProductID = productID,
                SpecialOfferID = specialOfferID,
                DataTable = DataTableInfo<SalesOrderDetailSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{salesOrderID}/{salesOrderDetailID}")]
        [ProducesResponseType(typeof(SalesOrderDetailLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesOrderDetailLookupModel>> Get(int salesOrderID, int salesOrderDetailID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSalesOrderDetailDetailQuery
            {
                SalesOrderID = salesOrderID,
                SalesOrderDetailID = salesOrderDetailID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(SalesOrderDetailLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseSalesOrderDetail model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesOrderDetailCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderDetailLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseSalesOrderDetail> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateSalesOrderDetailSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{salesOrderID}/{salesOrderDetailID}")]
        [ProducesResponseType(typeof(SalesOrderDetailLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int salesOrderID, int salesOrderDetailID, UpdateSalesOrderDetailCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderDetailLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateSalesOrderDetailCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateSalesOrderDetailSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{salesOrderID}/{salesOrderDetailID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int salesOrderID, int salesOrderDetailID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteSalesOrderDetailCommand
            {
                SalesOrderID = salesOrderID,
                SalesOrderDetailID = salesOrderDetailID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<SalesOrderDetailLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteSalesOrderDetailCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteSalesOrderDetailSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}