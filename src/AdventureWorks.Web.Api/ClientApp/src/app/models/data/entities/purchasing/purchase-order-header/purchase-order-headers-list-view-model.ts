import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';
import { IPurchaseOrderHeaderSummary } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-summary';

export interface IPurchaseOrderHeadersListViewModel {
  purchaseOrderHeaders?: Array<IPurchaseOrderHeaderLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IPurchaseOrderHeaderSummary;
  };
}
