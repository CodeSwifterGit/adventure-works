import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ILocationLookupModel } from 'app/models/data/entities/production/location/location-lookup-model';
import { ILocationSummary } from 'app/models/data/entities/production/location/location-summary';

export interface ILocationsListViewModel {
  locations?: Array<ILocationLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ILocationSummary;
  };
}
