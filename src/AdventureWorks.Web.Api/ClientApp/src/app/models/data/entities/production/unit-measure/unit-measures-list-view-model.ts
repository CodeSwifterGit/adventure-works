import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IUnitMeasureLookupModel } from 'app/models/data/entities/production/unit-measure/unit-measure-lookup-model';
import { IUnitMeasureSummary } from 'app/models/data/entities/production/unit-measure/unit-measure-summary';

export interface IUnitMeasuresListViewModel {
  unitMeasures?: Array<IUnitMeasureLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IUnitMeasureSummary;
  };
}
