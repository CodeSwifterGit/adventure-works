import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';
import { ISalesTerritorySummary } from 'app/models/data/entities/sales/sales-territory/sales-territory-summary';

export interface ISalesTerritoriesListViewModel {
  salesTerritories?: Array<ISalesTerritoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesTerritorySummary;
  };
}
