import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IDatabaseLogLookupModel } from 'app/models/data/entities/dbo/database-log/database-log-lookup-model';
import { IDatabaseLogSummary } from 'app/models/data/entities/dbo/database-log/database-log-summary';

export interface IDatabaseLogsListViewModel {
  databaseLogs?: Array<IDatabaseLogLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IDatabaseLogSummary;
  };
}
