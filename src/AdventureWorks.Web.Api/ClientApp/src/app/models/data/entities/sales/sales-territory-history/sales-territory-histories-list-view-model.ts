import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesTerritoryHistorySummary } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-summary';
import { ISalesTerritoryHistoryLookupModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-lookup-model';

export interface ISalesTerritoryHistoriesListViewModel {
  salesTerritoryHistories?: Array<ISalesTerritoryHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesTerritoryHistorySummary;
  };
}
