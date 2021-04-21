import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IWorkOrderRoutingSummary } from 'app/models/data/entities/production/work-order-routing/work-order-routing-summary';
import { IWorkOrderRoutingLookupModel } from 'app/models/data/entities/production/work-order-routing/work-order-routing-lookup-model';

export interface IWorkOrderRoutingsListViewModel {
  workOrderRoutings?: Array<IWorkOrderRoutingLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IWorkOrderRoutingSummary;
  };
}
