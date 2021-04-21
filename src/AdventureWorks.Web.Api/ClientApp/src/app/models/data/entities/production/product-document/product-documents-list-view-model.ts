import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductDocumentSummary } from 'app/models/data/entities/production/product-document/product-document-summary';
import { IProductDocumentLookupModel } from 'app/models/data/entities/production/product-document/product-document-lookup-model';

export interface IProductDocumentsListViewModel {
  productDocuments?: Array<IProductDocumentLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductDocumentSummary;
  };
}
