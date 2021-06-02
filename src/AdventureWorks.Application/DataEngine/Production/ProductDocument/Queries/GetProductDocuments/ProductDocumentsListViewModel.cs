using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments
{
    public partial class ProductDocumentsListViewModel
    {
        public IList<ProductDocumentLookupModel> ProductDocuments { get; set; }
        public DataTableResponseInfo<ProductDocumentSummary> DataTable { get; set; }
    }
}
