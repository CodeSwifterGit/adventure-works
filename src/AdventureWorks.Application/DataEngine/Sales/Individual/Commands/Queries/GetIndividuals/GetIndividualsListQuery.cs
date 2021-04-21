using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals
{
    public partial class GetIndividualsListQuery : IRequest<IndividualsListViewModel>, IDataTableInfo<IndividualSummary>
    {
        public DataTableInfo<IndividualSummary> DataTable { get; set; }
    }
}
