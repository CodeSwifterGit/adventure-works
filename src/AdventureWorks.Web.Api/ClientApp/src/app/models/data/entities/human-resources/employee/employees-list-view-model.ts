import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IEmployeeSummary } from 'app/models/data/entities/human-resources/employee/employee-summary';
import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';

export interface IEmployeesListViewModel {
  employees?: Array<IEmployeeLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IEmployeeSummary;
  };
}
