import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICustomerLookupModel } from 'app/models/data/entities/sales/customer/customer-lookup-model';
import { ICustomerSummary } from 'app/models/data/entities/sales/customer/customer-summary';

export interface ICustomersListViewModel {
  customers?: Array<ICustomerLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICustomerSummary;
  };
}
