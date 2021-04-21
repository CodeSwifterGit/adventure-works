import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductSummary } from 'app/models/data/entities/production/product/product-summary';
import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';

export interface IProductsListViewModel {
  products?: Array<IProductLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductSummary;
  };
}
