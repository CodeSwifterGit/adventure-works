using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates
{
    public partial class GetJobCandidatesByEmployeeListQueryHandler : IRequestHandler<GetJobCandidatesByEmployeeListQuery, JobCandidatesListViewModel>
    {
        private readonly JobCandidatesQueryManager _queryManager;

        public GetJobCandidatesByEmployeeListQueryHandler(JobCandidatesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<JobCandidatesListViewModel> Handle(GetJobCandidatesByEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.EmployeeID == request.EmployeeID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new JobCandidatesListViewModel
            {
                JobCandidates = listResult,
                DataTable = DataTableResponseInfo<JobCandidateSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
