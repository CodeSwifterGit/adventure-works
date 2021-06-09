import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesReasonLookupModel } from 'app/models/data/entities/sales/sales-reason/sales-reason-lookup-model';
import { ISalesReasonSummary } from 'app/models/data/entities/sales/sales-reason/sales-reason-summary';

export interface ISalesReasonsListViewModel {
  salesReasons?: Array<ISalesReasonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesReasonSummary;
  };
}
