import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IShiftLookupModel } from 'app/models/data/entities/human-resources/shift/shift-lookup-model';
import { IShiftSummary } from 'app/models/data/entities/human-resources/shift/shift-summary';

export interface IShiftsListViewModel {
  shifts?: Array<IShiftLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IShiftSummary;
  };
}
