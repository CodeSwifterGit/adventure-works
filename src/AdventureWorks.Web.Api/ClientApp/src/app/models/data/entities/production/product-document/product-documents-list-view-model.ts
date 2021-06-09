import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductDocumentLookupModel } from 'app/models/data/entities/production/product-document/product-document-lookup-model';
import { IProductDocumentSummary } from 'app/models/data/entities/production/product-document/product-document-summary';

export interface IProductDocumentsListViewModel {
  productDocuments?: Array<IProductDocumentLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductDocumentSummary;
  };
}
