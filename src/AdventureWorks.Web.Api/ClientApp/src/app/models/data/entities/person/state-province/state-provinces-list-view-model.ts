import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IStateProvinceLookupModel } from 'app/models/data/entities/person/state-province/state-province-lookup-model';
import { IStateProvinceSummary } from 'app/models/data/entities/person/state-province/state-province-summary';

export interface IStateProvincesListViewModel {
  stateProvinces?: Array<IStateProvinceLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IStateProvinceSummary;
  };
}
