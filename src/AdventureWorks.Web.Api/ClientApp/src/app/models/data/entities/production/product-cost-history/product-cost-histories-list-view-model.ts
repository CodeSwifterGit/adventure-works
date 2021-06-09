import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductCostHistoryLookupModel } from 'app/models/data/entities/production/product-cost-history/product-cost-history-lookup-model';
import { IProductCostHistorySummary } from 'app/models/data/entities/production/product-cost-history/product-cost-history-summary';

export interface IProductCostHistoriesListViewModel {
  productCostHistories?: Array<IProductCostHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductCostHistorySummary;
  };
}
