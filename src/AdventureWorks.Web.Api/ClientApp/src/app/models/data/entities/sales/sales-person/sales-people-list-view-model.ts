import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesPersonLookupModel } from 'app/models/data/entities/sales/sales-person/sales-person-lookup-model';
import { ISalesPersonSummary } from 'app/models/data/entities/sales/sales-person/sales-person-summary';

export interface ISalesPeopleListViewModel {
  salesPeople?: Array<ISalesPersonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesPersonSummary;
  };
}
