import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductModelLookupModel } from 'app/models/data/entities/production/product-model/product-model-lookup-model';
import { IProductModelSummary } from 'app/models/data/entities/production/product-model/product-model-summary';

export interface IProductModelsListViewModel {
  productModels?: Array<IProductModelLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductModelSummary;
  };
}
