import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IDepartmentLookupModel } from 'app/models/data/entities/human-resources/department/department-lookup-model';
import { IDepartmentSummary } from 'app/models/data/entities/human-resources/department/department-summary';

export interface IDepartmentsListViewModel {
  departments?: Array<IDepartmentLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IDepartmentSummary;
  };
}
