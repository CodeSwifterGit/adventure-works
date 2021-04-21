import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICustomerSummary } from 'app/models/data/entities/sales/customer/customer-summary';
import { ICustomerLookupModel } from 'app/models/data/entities/sales/customer/customer-lookup-model';

export interface ICustomersListViewModel {
  customers?: Array<ICustomerLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICustomerSummary;
  };
}
