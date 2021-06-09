import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IAddressLookupModel } from 'app/models/data/entities/person/address/address-lookup-model';
import { IAddressSummary } from 'app/models/data/entities/person/address/address-summary';

export interface IAddressesListViewModel {
  addresses?: Array<IAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IAddressSummary;
  };
}
