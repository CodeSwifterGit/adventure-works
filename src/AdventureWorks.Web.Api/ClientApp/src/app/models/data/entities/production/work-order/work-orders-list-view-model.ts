import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IWorkOrderLookupModel } from 'app/models/data/entities/production/work-order/work-order-lookup-model';
import { IWorkOrderSummary } from 'app/models/data/entities/production/work-order/work-order-summary';

export interface IWorkOrdersListViewModel {
  workOrders?: Array<IWorkOrderLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IWorkOrderSummary;
  };
}
