import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { IContactSummary } from 'app/models/data/entities/person/contact/contact-summary';

export interface IContactsListViewModel {
  contacts?: Array<IContactLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IContactSummary;
  };
}
