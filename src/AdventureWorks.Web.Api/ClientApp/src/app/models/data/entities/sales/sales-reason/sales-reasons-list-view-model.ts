import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesReasonSummary } from 'app/models/data/entities/sales/sales-reason/sales-reason-summary';
import { ISalesReasonLookupModel } from 'app/models/data/entities/sales/sales-reason/sales-reason-lookup-model';

export interface ISalesReasonsListViewModel {
  salesReasons?: Array<ISalesReasonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesReasonSummary;
  };
}
