import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesOrderHeaderSalesReasonLookupModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-lookup-model';
import { ISalesOrderHeaderSalesReasonSummary } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-summary';

export interface ISalesOrderHeaderSalesReasonsListViewModel {
  salesOrderHeaderSalesReasons?: Array<ISalesOrderHeaderSalesReasonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesOrderHeaderSalesReasonSummary;
  };
}
