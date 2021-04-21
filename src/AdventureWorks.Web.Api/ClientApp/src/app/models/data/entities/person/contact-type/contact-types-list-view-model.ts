import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IContactTypeSummary } from 'app/models/data/entities/person/contact-type/contact-type-summary';
import { IContactTypeLookupModel } from 'app/models/data/entities/person/contact-type/contact-type-lookup-model';

export interface IContactTypesListViewModel {
  contactTypes?: Array<IContactTypeLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IContactTypeSummary;
  };
}
