import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesOrderDetailSummary } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-summary';
import { ISalesOrderDetailLookupModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-lookup-model';

export interface ISalesOrderDetailsListViewModel {
  salesOrderDetails?: Array<ISalesOrderDetailLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesOrderDetailSummary;
  };
}
