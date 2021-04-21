import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IEmployeeDepartmentHistorySummary } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-summary';
import { IEmployeeDepartmentHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-lookup-model';

export interface IEmployeeDepartmentHistoriesListViewModel {
  employeeDepartmentHistories?: Array<IEmployeeDepartmentHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IEmployeeDepartmentHistorySummary;
  };
}
