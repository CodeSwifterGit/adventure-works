import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IScrapReasonLookupModel } from 'app/models/data/entities/production/scrap-reason/scrap-reason-lookup-model';
import { IScrapReasonSummary } from 'app/models/data/entities/production/scrap-reason/scrap-reason-summary';

export interface IScrapReasonsListViewModel {
  scrapReasons?: Array<IScrapReasonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IScrapReasonSummary;
  };
}
