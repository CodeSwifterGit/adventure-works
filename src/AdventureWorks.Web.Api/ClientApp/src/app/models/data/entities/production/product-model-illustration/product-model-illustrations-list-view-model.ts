import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductModelIllustrationSummary } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-summary';
import { IProductModelIllustrationLookupModel } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-lookup-model';

export interface IProductModelIllustrationsListViewModel {
  productModelIllustrations?: Array<IProductModelIllustrationLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductModelIllustrationSummary;
  };
}
