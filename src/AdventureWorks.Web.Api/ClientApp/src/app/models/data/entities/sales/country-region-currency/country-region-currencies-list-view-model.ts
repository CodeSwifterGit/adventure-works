import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICountryRegionCurrencyLookupModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-lookup-model';
import { ICountryRegionCurrencySummary } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-summary';

export interface ICountryRegionCurrenciesListViewModel {
  countryRegionCurrencies?: Array<ICountryRegionCurrencyLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICountryRegionCurrencySummary;
  };
}
