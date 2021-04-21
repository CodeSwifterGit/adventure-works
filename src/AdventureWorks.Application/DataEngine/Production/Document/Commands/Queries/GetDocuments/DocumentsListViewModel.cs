using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments
{
    public partial class DocumentsListViewModel
    {
        public IList<DocumentLookupModel> Documents { get; set; }
        public DataTableResponseInfo<DocumentSummary> DataTable { get; set; }
    }
}
