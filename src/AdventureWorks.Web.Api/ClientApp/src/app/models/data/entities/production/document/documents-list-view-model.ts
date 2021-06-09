import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IDocumentLookupModel } from 'app/models/data/entities/production/document/document-lookup-model';
import { IDocumentSummary } from 'app/models/data/entities/production/document/document-summary';

export interface IDocumentsListViewModel {
  documents?: Array<IDocumentLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IDocumentSummary;
  };
}
