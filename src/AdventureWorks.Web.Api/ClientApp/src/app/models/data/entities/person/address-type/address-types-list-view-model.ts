import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IAddressTypeLookupModel } from 'app/models/data/entities/person/address-type/address-type-lookup-model';
import { IAddressTypeSummary } from 'app/models/data/entities/person/address-type/address-type-summary';

export interface IAddressTypesListViewModel {
  addressTypes?: Array<IAddressTypeLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IAddressTypeSummary;
  };
}
