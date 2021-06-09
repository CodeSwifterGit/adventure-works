import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ITransactionHistoryLookupModel } from 'app/models/data/entities/production/transaction-history/transaction-history-lookup-model';
import { ITransactionHistorySummary } from 'app/models/data/entities/production/transaction-history/transaction-history-summary';

export interface ITransactionHistoriesListViewModel {
  transactionHistories?: Array<ITransactionHistoryLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ITransactionHistorySummary;
  };
}
