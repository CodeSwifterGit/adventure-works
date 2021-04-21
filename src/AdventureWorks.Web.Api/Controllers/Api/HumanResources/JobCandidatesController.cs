using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.CreateJobCandidate;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.DeleteJobCandidate;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.UpdateJobCandidate;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidateDetail;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.HumanResources
{
    public partial class JobCandidatesController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{employeeID}")]
        [ProducesResponseType(typeof(JobCandidatesListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<JobCandidatesListViewModel>> GetJobCandidatesByEmployee(
            int? employeeID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetJobCandidatesByEmployeeListQuery()
            {
                EmployeeID = employeeID,
                DataTable = DataTableInfo<JobCandidateSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{jobCandidateID}")]
        [ProducesResponseType(typeof(JobCandidateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<JobCandidateLookupModel>> Get(int jobCandidateID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetJobCandidateDetailQuery
            {
                JobCandidateID = jobCandidateID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(JobCandidateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseJobCandidate model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateJobCandidateCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<JobCandidateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseJobCandidate> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateJobCandidateSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{jobCandidateID}")]
        [ProducesResponseType(typeof(JobCandidateLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int jobCandidateID, UpdateJobCandidateCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<JobCandidateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateJobCandidateCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateJobCandidateSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{jobCandidateID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int jobCandidateID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteJobCandidateCommand
            {
                JobCandidateID = jobCandidateID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<JobCandidateLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteJobCandidateCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteJobCandidateSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}