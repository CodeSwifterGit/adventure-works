import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IErrorLogLookupModel } from 'app/models/data/entities/dbo/error-log/error-log-lookup-model';
import { IErrorLogSummary } from 'app/models/data/entities/dbo/error-log/error-log-summary';

export interface IErrorLogsListViewModel {
  errorLogs?: Array<IErrorLogLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IErrorLogSummary;
  };
}
