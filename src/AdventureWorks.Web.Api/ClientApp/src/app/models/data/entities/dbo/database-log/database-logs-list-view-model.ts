import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IDatabaseLogSummary } from 'app/models/data/entities/dbo/database-log/database-log-summary';
import { IDatabaseLogLookupModel } from 'app/models/data/entities/dbo/database-log/database-log-lookup-model';

export interface IDatabaseLogsListViewModel {
  databaseLogs?: Array<IDatabaseLogLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IDatabaseLogSummary;
  };
}
