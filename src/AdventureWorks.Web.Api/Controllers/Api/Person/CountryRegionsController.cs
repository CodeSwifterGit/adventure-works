using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.CreateCountryRegion;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.DeleteCountryRegion;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.UpdateCountryRegion;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegionDetail;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Person
{
    public partial class CountryRegionsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("all")]
        [ProducesResponseType(typeof(CountryRegionsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CountryRegionsListViewModel>> GetAll(
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCountryRegionsListQuery()
            {
                DataTable = DataTableInfo<CountryRegionSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{countryRegionCode}")]
        [ProducesResponseType(typeof(CountryRegionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CountryRegionLookupModel>> Get(string countryRegionCode, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCountryRegionDetailQuery
            {
                CountryRegionCode = countryRegionCode
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(CountryRegionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseCountryRegion model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCountryRegionCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CountryRegionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseCountryRegion> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCountryRegionSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{countryRegionCode}")]
        [ProducesResponseType(typeof(CountryRegionLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(string countryRegionCode, UpdateCountryRegionCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<CountryRegionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateCountryRegionCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateCountryRegionSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{countryRegionCode}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string countryRegionCode, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCountryRegionCommand
            {
                CountryRegionCode = countryRegionCode
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<CountryRegionLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteCountryRegionCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteCountryRegionSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}