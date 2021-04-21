import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IWorkOrderSummary } from 'app/models/data/entities/production/work-order/work-order-summary';
import { IWorkOrderLookupModel } from 'app/models/data/entities/production/work-order/work-order-lookup-model';

export interface IWorkOrdersListViewModel {
  workOrders?: Array<IWorkOrderLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IWorkOrderSummary;
  };
}
