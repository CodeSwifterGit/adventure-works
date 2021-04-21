import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductReviewSummary } from 'app/models/data/entities/production/product-review/product-review-summary';
import { IProductReviewLookupModel } from 'app/models/data/entities/production/product-review/product-review-lookup-model';

export interface IProductReviewsListViewModel {
  productReviews?: Array<IProductReviewLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductReviewSummary;
  };
}
