import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IUnitMeasureSummary } from 'app/models/data/entities/production/unit-measure/unit-measure-summary';
import { IUnitMeasureLookupModel } from 'app/models/data/entities/production/unit-measure/unit-measure-lookup-model';

export interface IUnitMeasuresListViewModel {
  unitMeasures?: Array<IUnitMeasureLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IUnitMeasureSummary;
  };
}
