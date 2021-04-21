using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates
{
    public partial class JobCandidatesListViewModel
    {
        public IList<JobCandidateLookupModel> JobCandidates { get; set; }
        public DataTableResponseInfo<JobCandidateSummary> DataTable { get; set; }
    }
}
