import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISpecialOfferLookupModel } from 'app/models/data/entities/sales/special-offer/special-offer-lookup-model';
import { ISpecialOfferSummary } from 'app/models/data/entities/sales/special-offer/special-offer-summary';

export interface ISpecialOffersListViewModel {
  specialOffers?: Array<ISpecialOfferLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISpecialOfferSummary;
  };
}
