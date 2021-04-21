import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IVendorAddressSummary } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-summary';
import { IVendorAddressLookupModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-lookup-model';

export interface IVendorAddressesListViewModel {
  vendorAddresses?: Array<IVendorAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IVendorAddressSummary;
  };
}
