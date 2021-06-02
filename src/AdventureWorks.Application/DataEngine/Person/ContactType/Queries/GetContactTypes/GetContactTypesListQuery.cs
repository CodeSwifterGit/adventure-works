using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes
{
    public partial class GetContactTypesListQuery : IRequest<ContactTypesListViewModel>, IDataTableInfo<ContactTypeSummary>
    {
        public DataTableInfo<ContactTypeSummary> DataTable { get; set; }
    }
}
