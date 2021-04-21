import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IEmployeePayHistorySummary } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history-summary';
import { IEmployeePayHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history-lookup-model';

export interface IEmployeePayHistoriesListViewModel {
  employeePayHistories?: Array<IEmployeePayHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IEmployeePayHistorySummary;
  };
}
