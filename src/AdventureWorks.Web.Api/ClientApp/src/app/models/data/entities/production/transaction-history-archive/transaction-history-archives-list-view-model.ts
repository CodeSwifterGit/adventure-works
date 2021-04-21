import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ITransactionHistoryArchiveSummary } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive-summary';
import { ITransactionHistoryArchiveLookupModel } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive-lookup-model';

export interface ITransactionHistoryArchivesListViewModel {
  transactionHistoryArchives?: Array<ITransactionHistoryArchiveLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ITransactionHistoryArchiveSummary;
  };
}
