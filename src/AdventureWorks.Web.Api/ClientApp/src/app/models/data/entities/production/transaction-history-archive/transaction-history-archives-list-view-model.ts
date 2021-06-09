import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ITransactionHistoryArchiveLookupModel } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive-lookup-model';
import { ITransactionHistoryArchiveSummary } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive-summary';

export interface ITransactionHistoryArchivesListViewModel {
  transactionHistoryArchives?: Array<ITransactionHistoryArchiveLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ITransactionHistoryArchiveSummary;
  };
}
