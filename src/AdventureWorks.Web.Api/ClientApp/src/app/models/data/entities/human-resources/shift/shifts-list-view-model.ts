import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IShiftSummary } from 'app/models/data/entities/human-resources/shift/shift-summary';
import { IShiftLookupModel } from 'app/models/data/entities/human-resources/shift/shift-lookup-model';

export interface IShiftsListViewModel {
  shifts?: Array<IShiftLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IShiftSummary;
  };
}
