import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesTerritoryHistoryLookupModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-lookup-model';
import { ISalesTerritoryHistorySummary } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-summary';

export interface ISalesTerritoryHistoriesListViewModel {
  salesTerritoryHistories?: Array<ISalesTerritoryHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesTerritoryHistorySummary;
  };
}
