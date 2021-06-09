import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductListPriceHistoryLookupModel } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history-lookup-model';
import { IProductListPriceHistorySummary } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history-summary';

export interface IProductListPriceHistoriesListViewModel {
  productListPriceHistories?: Array<IProductListPriceHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductListPriceHistorySummary;
  };
}
