import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductCategorySummary } from 'app/models/data/entities/production/product-category/product-category-summary';
import { IProductCategoryLookupModel } from 'app/models/data/entities/production/product-category/product-category-lookup-model';

export interface IProductCategoriesListViewModel {
  productCategories?: Array<IProductCategoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductCategorySummary;
  };
}
