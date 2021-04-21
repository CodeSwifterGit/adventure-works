import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IVendorSummary } from 'app/models/data/entities/purchasing/vendor/vendor-summary';
import { IVendorLookupModel } from 'app/models/data/entities/purchasing/vendor/vendor-lookup-model';

export interface IVendorsListViewModel {
  vendors?: Array<IVendorLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IVendorSummary;
  };
}
