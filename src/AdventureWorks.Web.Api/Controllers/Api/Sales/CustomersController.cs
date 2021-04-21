using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Sales.Customer.Commands.CreateCustomer;
using AdventureWorks.Application.DataEngine.Sales.Customer.Commands.DeleteCustomer;
using AdventureWorks.Application.DataEngine.Sales.Customer.Commands.UpdateCustomer;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomerDetail;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Sales
{
    public partial class CustomersController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{territoryID}")]
        [ProducesResponseType(typeof(CustomersListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomersListViewModel>> GetCustomersBySalesTerritory(
            int? territoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomersBySalesTerritoryListQuery()
            {
                TerritoryID = territoryID,
                DataTable = DataTableInfo<CustomerSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{customerID}")]
        [ProducesResponseType(typeof(CustomerLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerLookupModel>> Get(int customerID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerDetailQuery
            {
                CustomerID = customerID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCustomer model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCustomerCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CustomerLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCustomer> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCustomerSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{customerID}")]
        [ProducesResponseType(typeof(CustomerLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int customerID, UpdateCustomerCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CustomerLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCustomerCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCustomerSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{customerID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int customerID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCustomerCommand
            {
                CustomerID = customerID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CustomerLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCustomerCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCustomerSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}