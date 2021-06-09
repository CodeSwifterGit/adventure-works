import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IPurchaseOrderDetailLookupModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-lookup-model';
import { IPurchaseOrderDetailSummary } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-summary';

export interface IPurchaseOrderDetailsListViewModel {
  purchaseOrderDetails?: Array<IPurchaseOrderDetailLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IPurchaseOrderDetailSummary;
  };
}
