using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals
{
    public partial class IndividualsListViewModel
    {
        public IList<IndividualLookupModel> Individuals { get; set; }
        public DataTableResponseInfo<IndividualSummary> DataTable { get; set; }
    }
}
