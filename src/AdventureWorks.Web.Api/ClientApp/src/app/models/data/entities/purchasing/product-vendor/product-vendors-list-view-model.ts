import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductVendorSummary } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-summary';
import { IProductVendorLookupModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-lookup-model';

export interface IProductVendorsListViewModel {
  productVendors?: Array<IProductVendorLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductVendorSummary;
  };
}
