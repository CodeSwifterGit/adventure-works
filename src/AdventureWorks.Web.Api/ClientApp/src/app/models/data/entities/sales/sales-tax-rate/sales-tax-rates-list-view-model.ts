import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ISalesTaxRateSummary } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-summary';
import { ISalesTaxRateLookupModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-lookup-model';

export interface ISalesTaxRatesListViewModel {
  salesTaxRates?: Array<ISalesTaxRateLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ISalesTaxRateSummary;
  };
}
