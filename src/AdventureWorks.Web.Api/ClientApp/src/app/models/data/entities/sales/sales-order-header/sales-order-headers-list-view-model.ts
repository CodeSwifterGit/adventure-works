import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISalesOrderHeaderSummary } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-summary';

export interface ISalesOrderHeadersListViewModel {
  salesOrderHeaders?: Array<ISalesOrderHeaderLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesOrderHeaderSummary;
  };
}
