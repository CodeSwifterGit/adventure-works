import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IScrapReasonSummary } from 'app/models/data/entities/production/scrap-reason/scrap-reason-summary';
import { IScrapReasonLookupModel } from 'app/models/data/entities/production/scrap-reason/scrap-reason-lookup-model';

export interface IScrapReasonsListViewModel {
  scrapReasons?: Array<IScrapReasonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IScrapReasonSummary;
  };
}
