import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IVendorAddressLookupModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-lookup-model';
import { IVendorAddressSummary } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-summary';

export interface IVendorAddressesListViewModel {
  vendorAddresses?: Array<IVendorAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IVendorAddressSummary;
  };
}
