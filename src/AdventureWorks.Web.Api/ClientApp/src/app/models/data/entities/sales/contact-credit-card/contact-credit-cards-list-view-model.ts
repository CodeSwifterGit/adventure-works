import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IContactCreditCardSummary } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-summary';
import { IContactCreditCardLookupModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-lookup-model';

export interface IContactCreditCardsListViewModel {
  contactCreditCards?: Array<IContactCreditCardLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IContactCreditCardSummary;
  };
}
