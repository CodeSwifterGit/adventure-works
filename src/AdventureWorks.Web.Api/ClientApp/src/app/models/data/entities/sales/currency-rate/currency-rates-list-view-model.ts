import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICurrencyRateLookupModel } from 'app/models/data/entities/sales/currency-rate/currency-rate-lookup-model';
import { ICurrencyRateSummary } from 'app/models/data/entities/sales/currency-rate/currency-rate-summary';

export interface ICurrencyRatesListViewModel {
  currencyRates?: Array<ICurrencyRateLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICurrencyRateSummary;
  };
}
