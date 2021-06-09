import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICultureLookupModel } from 'app/models/data/entities/production/culture/culture-lookup-model';
import { ICultureSummary } from 'app/models/data/entities/production/culture/culture-summary';

export interface ICulturesListViewModel {
  cultures?: Array<ICultureLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICultureSummary;
  };
}
