import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISpecialOfferProductSummary } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-summary';
import { ISpecialOfferProductLookupModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-lookup-model';

export interface ISpecialOfferProductsListViewModel {
  specialOfferProducts?: Array<ISpecialOfferProductLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISpecialOfferProductSummary;
  };
}
