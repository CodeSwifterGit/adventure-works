import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductModelProductDescriptionCultureLookupModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-lookup-model';
import { IProductModelProductDescriptionCultureSummary } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-summary';

export interface IProductModelProductDescriptionCulturesListViewModel {
  productModelProductDescriptionCultures?: Array<IProductModelProductDescriptionCultureLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductModelProductDescriptionCultureSummary;
  };
}
