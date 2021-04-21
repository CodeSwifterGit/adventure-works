import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IAddressSummary } from 'app/models/data/entities/person/address/address-summary';
import { IAddressLookupModel } from 'app/models/data/entities/person/address/address-lookup-model';

export interface IAddressesListViewModel {
  addresses?: Array<IAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IAddressSummary;
  };
}
