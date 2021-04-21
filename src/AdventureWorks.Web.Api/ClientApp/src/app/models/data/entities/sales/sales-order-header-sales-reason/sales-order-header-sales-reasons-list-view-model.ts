import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesOrderHeaderSalesReasonSummary } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-summary';
import { ISalesOrderHeaderSalesReasonLookupModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-lookup-model';

export interface ISalesOrderHeaderSalesReasonsListViewModel {
  salesOrderHeaderSalesReasons?: Array<ISalesOrderHeaderSalesReasonLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesOrderHeaderSalesReasonSummary;
  };
}
