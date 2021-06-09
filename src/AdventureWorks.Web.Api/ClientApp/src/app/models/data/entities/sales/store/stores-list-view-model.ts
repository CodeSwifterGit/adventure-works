import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IStoreLookupModel } from 'app/models/data/entities/sales/store/store-lookup-model';
import { IStoreSummary } from 'app/models/data/entities/sales/store/store-summary';

export interface IStoresListViewModel {
  stores?: Array<IStoreLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IStoreSummary;
  };
}
