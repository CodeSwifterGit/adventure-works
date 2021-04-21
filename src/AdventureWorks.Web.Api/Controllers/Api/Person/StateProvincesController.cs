using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.CreateStateProvince;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.DeleteStateProvince;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinceDetail;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Person
{
    public partial class StateProvincesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{countryRegionCode}")]
        [ProducesResponseType(typeof(StateProvincesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StateProvincesListViewModel>> GetStateProvincesByCountryRegion(
            string countryRegionCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStateProvincesByCountryRegionListQuery()
            {
                CountryRegionCode = countryRegionCode,
                DataTable = DataTableInfo<StateProvinceSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{territoryID}")]
        [ProducesResponseType(typeof(StateProvincesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StateProvincesListViewModel>> GetStateProvincesBySalesTerritory(
            int territoryID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStateProvincesBySalesTerritoryListQuery()
            {
                TerritoryID = territoryID,
                DataTable = DataTableInfo<StateProvinceSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{stateProvinceID}")]
        [ProducesResponseType(typeof(StateProvinceLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StateProvinceLookupModel>> Get(int stateProvinceID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStateProvinceDetailQuery
            {
                StateProvinceID = stateProvinceID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(StateProvinceLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseStateProvince model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStateProvinceCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<StateProvinceLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseStateProvince> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStateProvinceSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{stateProvinceID}")]
        [ProducesResponseType(typeof(StateProvinceLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int stateProvinceID, UpdateStateProvinceCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<StateProvinceLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateStateProvinceCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateStateProvinceSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{stateProvinceID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int stateProvinceID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteStateProvinceCommand
            {
                StateProvinceID = stateProvinceID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<StateProvinceLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteStateProvinceCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteStateProvinceSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}