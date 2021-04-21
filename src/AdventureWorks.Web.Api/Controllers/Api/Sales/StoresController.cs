using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.Store.Commands.CreateStore;
using AdventureWorks.Application.DataEngine.Sales.Store.Commands.DeleteStore;
using AdventureWorks.Application.DataEngine.Sales.Store.Commands.UpdateStore;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStoreDetail;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class StoresController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{customerID}")]
        [ProducesResponseType(typeof(StoresListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoresListViewModel>> GetStoresByCustomer(
            int customerID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoresByCustomerListQuery()
            {
                CustomerID = customerID,
                DataTable = DataTableInfo<StoreSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{salesPersonID}")]
        [ProducesResponseType(typeof(StoresListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoresListViewModel>> GetStoresBySalesPerson(
            int? salesPersonID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoresBySalesPersonListQuery()
            {
                SalesPersonID = salesPersonID,
                DataTable = DataTableInfo<StoreSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{customerID}")]
        [ProducesResponseType(typeof(StoreLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoreLookupModel>> Get(int customerID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStoreDetailQuery
            {
                CustomerID = customerID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(StoreLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseStore model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStoreCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<StoreLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseStore> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStoreSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{customerID}")]
        [ProducesResponseType(typeof(StoreLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int customerID, UpdateStoreCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<StoreLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateStoreCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateStoreSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{customerID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int customerID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteStoreCommand
            {
                CustomerID = customerID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<StoreLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteStoreCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteStoreSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}