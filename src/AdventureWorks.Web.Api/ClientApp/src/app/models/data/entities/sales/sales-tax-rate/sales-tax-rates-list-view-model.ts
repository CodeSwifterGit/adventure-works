import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesTaxRateLookupModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-lookup-model';
import { ISalesTaxRateSummary } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-summary';

export interface ISalesTaxRatesListViewModel {
  salesTaxRates?: Array<ISalesTaxRateLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesTaxRateSummary;
  };
}
