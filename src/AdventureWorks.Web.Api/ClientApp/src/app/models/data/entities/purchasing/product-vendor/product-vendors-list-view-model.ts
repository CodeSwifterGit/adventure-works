import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductVendorLookupModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-lookup-model';
import { IProductVendorSummary } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-summary';

export interface IProductVendorsListViewModel {
  productVendors?: Array<IProductVendorLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductVendorSummary;
  };
}
