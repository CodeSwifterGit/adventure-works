import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductModelIllustrationLookupModel } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-lookup-model';
import { IProductModelIllustrationSummary } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-summary';

export interface IProductModelIllustrationsListViewModel {
  productModelIllustrations?: Array<IProductModelIllustrationLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductModelIllustrationSummary;
  };
}
