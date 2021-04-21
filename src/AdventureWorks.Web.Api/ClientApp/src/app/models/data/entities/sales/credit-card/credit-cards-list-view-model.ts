import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICreditCardSummary } from 'app/models/data/entities/sales/credit-card/credit-card-summary';
import { ICreditCardLookupModel } from 'app/models/data/entities/sales/credit-card/credit-card-lookup-model';

export interface ICreditCardsListViewModel {
  creditCards?: Array<ICreditCardLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICreditCardSummary;
  };
}
