import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IShipMethodLookupModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-lookup-model';
import { IShipMethodSummary } from 'app/models/data/entities/purchasing/ship-method/ship-method-summary';

export interface IShipMethodsListViewModel {
  shipMethods?: Array<IShipMethodLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IShipMethodSummary;
  };
}
