import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductSubcategorySummary } from 'app/models/data/entities/production/product-subcategory/product-subcategory-summary';
import { IProductSubcategoryLookupModel } from 'app/models/data/entities/production/product-subcategory/product-subcategory-lookup-model';

export interface IProductSubcategoriesListViewModel {
  productSubcategories?: Array<IProductSubcategoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductSubcategorySummary;
  };
}
