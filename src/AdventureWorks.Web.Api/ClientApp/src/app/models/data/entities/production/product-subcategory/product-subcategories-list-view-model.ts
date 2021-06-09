import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductSubcategoryLookupModel } from 'app/models/data/entities/production/product-subcategory/product-subcategory-lookup-model';
import { IProductSubcategorySummary } from 'app/models/data/entities/production/product-subcategory/product-subcategory-summary';

export interface IProductSubcategoriesListViewModel {
  productSubcategories?: Array<IProductSubcategoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductSubcategorySummary;
  };
}
