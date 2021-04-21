import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesPersonSummary } from 'app/models/data/entities/sales/sales-person/sales-person-summary';
import { ISalesPersonLookupModel } from 'app/models/data/entities/sales/sales-person/sales-person-lookup-model';

export interface ISalesPeopleListViewModel {
  salesPeople?: Array<ISalesPersonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesPersonSummary;
  };
}
