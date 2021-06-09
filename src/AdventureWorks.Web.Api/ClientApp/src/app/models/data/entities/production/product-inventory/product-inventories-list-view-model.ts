import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductInventoryLookupModel } from 'app/models/data/entities/production/product-inventory/product-inventory-lookup-model';
import { IProductInventorySummary } from 'app/models/data/entities/production/product-inventory/product-inventory-summary';

export interface IProductInventoriesListViewModel {
  productInventories?: Array<IProductInventoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductInventorySummary;
  };
}
