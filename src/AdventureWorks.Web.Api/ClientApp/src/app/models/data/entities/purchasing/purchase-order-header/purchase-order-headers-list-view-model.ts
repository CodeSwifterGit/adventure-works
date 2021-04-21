import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IPurchaseOrderHeaderSummary } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-summary';
import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';

export interface IPurchaseOrderHeadersListViewModel {
  purchaseOrderHeaders?: Array<IPurchaseOrderHeaderLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IPurchaseOrderHeaderSummary;
  };
}
