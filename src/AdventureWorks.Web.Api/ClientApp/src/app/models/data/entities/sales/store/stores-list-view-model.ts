import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IStoreSummary } from 'app/models/data/entities/sales/store/store-summary';
import { IStoreLookupModel } from 'app/models/data/entities/sales/store/store-lookup-model';

export interface IStoresListViewModel {
  stores?: Array<IStoreLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IStoreSummary;
  };
}
