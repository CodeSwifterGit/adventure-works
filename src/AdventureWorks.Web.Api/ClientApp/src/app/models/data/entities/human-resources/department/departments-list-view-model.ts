import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IDepartmentSummary } from 'app/models/data/entities/human-resources/department/department-summary';
import { IDepartmentLookupModel } from 'app/models/data/entities/human-resources/department/department-lookup-model';

export interface IDepartmentsListViewModel {
  departments?: Array<IDepartmentLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IDepartmentSummary;
  };
}
