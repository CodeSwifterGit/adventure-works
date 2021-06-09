import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { IProductSummary } from 'app/models/data/entities/production/product/product-summary';

export interface IProductsListViewModel {
  products?: Array<IProductLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductSummary;
  };
}
