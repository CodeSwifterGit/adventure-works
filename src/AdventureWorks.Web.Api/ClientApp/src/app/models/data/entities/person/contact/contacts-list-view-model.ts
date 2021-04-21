import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IContactSummary } from 'app/models/data/entities/person/contact/contact-summary';
import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';

export interface IContactsListViewModel {
  contacts?: Array<IContactLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IContactSummary;
  };
}
