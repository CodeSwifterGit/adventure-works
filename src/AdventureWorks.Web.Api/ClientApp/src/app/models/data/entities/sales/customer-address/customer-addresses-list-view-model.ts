import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICustomerAddressSummary } from 'app/models/data/entities/sales/customer-address/customer-address-summary';
import { ICustomerAddressLookupModel } from 'app/models/data/entities/sales/customer-address/customer-address-lookup-model';

export interface ICustomerAddressesListViewModel {
  customerAddresses?: Array<ICustomerAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICustomerAddressSummary;
  };
}
