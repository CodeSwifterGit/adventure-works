import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICustomerAddressLookupModel } from 'app/models/data/entities/sales/customer-address/customer-address-lookup-model';
import { ICustomerAddressSummary } from 'app/models/data/entities/sales/customer-address/customer-address-summary';

export interface ICustomerAddressesListViewModel {
  customerAddresses?: Array<ICustomerAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICustomerAddressSummary;
  };
}
