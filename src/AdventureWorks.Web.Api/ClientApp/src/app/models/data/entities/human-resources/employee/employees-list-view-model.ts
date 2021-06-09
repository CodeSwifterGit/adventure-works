import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';
import { IEmployeeSummary } from 'app/models/data/entities/human-resources/employee/employee-summary';

export interface IEmployeesListViewModel {
  employees?: Array<IEmployeeLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IEmployeeSummary;
  };
}
