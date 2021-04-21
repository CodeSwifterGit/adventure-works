import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IStoreContactSummary } from 'app/models/data/entities/sales/store-contact/store-contact-summary';
import { IStoreContactLookupModel } from 'app/models/data/entities/sales/store-contact/store-contact-lookup-model';

export interface IStoreContactsListViewModel {
  storeContacts?: Array<IStoreContactLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IStoreContactSummary;
  };
}
