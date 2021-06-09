import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductReviewLookupModel } from 'app/models/data/entities/production/product-review/product-review-lookup-model';
import { IProductReviewSummary } from 'app/models/data/entities/production/product-review/product-review-summary';

export interface IProductReviewsListViewModel {
  productReviews?: Array<IProductReviewLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductReviewSummary;
  };
}
