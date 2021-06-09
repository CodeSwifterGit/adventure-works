import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesPersonQuotaHistoryLookupModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-lookup-model';
import { ISalesPersonQuotaHistorySummary } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-summary';

export interface ISalesPersonQuotaHistoriesListViewModel {
  salesPersonQuotaHistories?: Array<ISalesPersonQuotaHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesPersonQuotaHistorySummary;
  };
}
