import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IStoreContactLookupModel } from 'app/models/data/entities/sales/store-contact/store-contact-lookup-model';
import { IStoreContactSummary } from 'app/models/data/entities/sales/store-contact/store-contact-summary';

export interface IStoreContactsListViewModel {
  storeContacts?: Array<IStoreContactLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IStoreContactSummary;
  };
}
