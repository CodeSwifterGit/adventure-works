import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IVendorContactLookupModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-lookup-model';
import { IVendorContactSummary } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-summary';

export interface IVendorContactsListViewModel {
  vendorContacts?: Array<IVendorContactLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IVendorContactSummary;
  };
}
