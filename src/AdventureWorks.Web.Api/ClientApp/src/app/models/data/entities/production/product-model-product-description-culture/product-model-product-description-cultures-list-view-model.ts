import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductModelProductDescriptionCultureSummary } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-summary';
import { IProductModelProductDescriptionCultureLookupModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-lookup-model';

export interface IProductModelProductDescriptionCulturesListViewModel {
  productModelProductDescriptionCultures?: Array<IProductModelProductDescriptionCultureLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductModelProductDescriptionCultureSummary;
  };
}
