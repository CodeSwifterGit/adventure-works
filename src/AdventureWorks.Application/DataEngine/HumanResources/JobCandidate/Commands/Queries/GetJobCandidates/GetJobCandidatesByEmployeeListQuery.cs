using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates
{
    public partial class GetJobCandidatesByEmployeeListQuery : IRequest<JobCandidatesListViewModel>, IDataTableInfo<JobCandidateSummary>
    {
        public int? EmployeeID { get; set; }
        public DataTableInfo<JobCandidateSummary> DataTable { get; set; }
    }
}
