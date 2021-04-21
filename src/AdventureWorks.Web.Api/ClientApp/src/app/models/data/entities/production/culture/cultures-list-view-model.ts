import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICultureSummary } from 'app/models/data/entities/production/culture/culture-summary';
import { ICultureLookupModel } from 'app/models/data/entities/production/culture/culture-lookup-model';

export interface ICulturesListViewModel {
  cultures?: Array<ICultureLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICultureSummary;
  };
}
