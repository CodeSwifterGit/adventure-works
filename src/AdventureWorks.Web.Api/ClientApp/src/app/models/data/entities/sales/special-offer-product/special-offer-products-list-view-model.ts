import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISpecialOfferProductLookupModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-lookup-model';
import { ISpecialOfferProductSummary } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-summary';

export interface ISpecialOfferProductsListViewModel {
  specialOfferProducts?: Array<ISpecialOfferProductLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISpecialOfferProductSummary;
  };
}
