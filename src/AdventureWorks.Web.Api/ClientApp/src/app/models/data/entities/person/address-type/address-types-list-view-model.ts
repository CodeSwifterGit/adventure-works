import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IAddressTypeSummary } from 'app/models/data/entities/person/address-type/address-type-summary';
import { IAddressTypeLookupModel } from 'app/models/data/entities/person/address-type/address-type-lookup-model';

export interface IAddressTypesListViewModel {
  addressTypes?: Array<IAddressTypeLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IAddressTypeSummary;
  };
}
