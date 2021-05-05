using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates
{
    public partial class GetJobCandidatesListQueryHandler : IRequestHandler<GetJobCandidatesListQuery, JobCandidatesListViewModel>
    {
        private readonly JobCandidatesQueryManager _queryManager;

        public GetJobCandidatesListQueryHandler(JobCandidatesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<JobCandidatesListViewModel> Handle(GetJobCandidatesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
