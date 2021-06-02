using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates
{
    public partial class GetJobCandidatesListQuery : IRequest<JobCandidatesListViewModel>, IDataTableInfo<JobCandidateSummary>
    {
        public DataTableInfo<JobCandidateSummary> DataTable { get; set; }
    }
}
