import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesOrderHeaderSummary } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-summary';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';

export interface ISalesOrderHeadersListViewModel {
  salesOrderHeaders?: Array<ISalesOrderHeaderLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesOrderHeaderSummary;
  };
}
