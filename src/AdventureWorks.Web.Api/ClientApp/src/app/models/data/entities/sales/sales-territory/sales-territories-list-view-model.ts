import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesTerritorySummary } from 'app/models/data/entities/sales/sales-territory/sales-territory-summary';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';

export interface ISalesTerritoriesListViewModel {
  salesTerritories?: Array<ISalesTerritoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesTerritorySummary;
  };
}
