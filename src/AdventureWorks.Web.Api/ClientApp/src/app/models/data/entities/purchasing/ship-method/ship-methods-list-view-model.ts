import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IShipMethodSummary } from 'app/models/data/entities/purchasing/ship-method/ship-method-summary';
import { IShipMethodLookupModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-lookup-model';

export interface IShipMethodsListViewModel {
  shipMethods?: Array<IShipMethodLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IShipMethodSummary;
  };
}
