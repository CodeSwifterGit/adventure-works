import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IErrorLogSummary } from 'app/models/data/entities/dbo/error-log/error-log-summary';
import { IErrorLogLookupModel } from 'app/models/data/entities/dbo/error-log/error-log-lookup-model';

export interface IErrorLogsListViewModel {
  errorLogs?: Array<IErrorLogLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IErrorLogSummary;
  };
}
