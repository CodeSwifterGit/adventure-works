import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductCategoryLookupModel } from 'app/models/data/entities/production/product-category/product-category-lookup-model';
import { IProductCategorySummary } from 'app/models/data/entities/production/product-category/product-category-summary';

export interface IProductCategoriesListViewModel {
  productCategories?: Array<IProductCategoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductCategorySummary;
  };
}
