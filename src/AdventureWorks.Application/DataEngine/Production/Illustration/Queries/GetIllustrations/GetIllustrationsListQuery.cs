using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations
{
    public partial class GetIllustrationsListQuery : IRequest<IllustrationsListViewModel>, IDataTableInfo<IllustrationSummary>
    {
        public DataTableInfo<IllustrationSummary> DataTable { get; set; }
    }
}
