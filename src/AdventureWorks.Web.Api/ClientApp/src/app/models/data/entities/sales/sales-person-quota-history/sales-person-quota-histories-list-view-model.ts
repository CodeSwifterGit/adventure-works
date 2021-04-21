import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesPersonQuotaHistorySummary } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-summary';
import { ISalesPersonQuotaHistoryLookupModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-lookup-model';

export interface ISalesPersonQuotaHistoriesListViewModel {
  salesPersonQuotaHistories?: Array<ISalesPersonQuotaHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesPersonQuotaHistorySummary;
  };
}
