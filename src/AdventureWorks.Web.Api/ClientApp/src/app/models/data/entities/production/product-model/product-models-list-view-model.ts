import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductModelSummary } from 'app/models/data/entities/production/product-model/product-model-summary';
import { IProductModelLookupModel } from 'app/models/data/entities/production/product-model/product-model-lookup-model';

export interface IProductModelsListViewModel {
  productModels?: Array<IProductModelLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductModelSummary;
  };
}
