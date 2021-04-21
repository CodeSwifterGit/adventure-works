import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICurrencySummary } from 'app/models/data/entities/sales/currency/currency-summary';
import { ICurrencyLookupModel } from 'app/models/data/entities/sales/currency/currency-lookup-model';

export interface ICurrenciesListViewModel {
  currencies?: Array<ICurrencyLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICurrencySummary;
  };
}
