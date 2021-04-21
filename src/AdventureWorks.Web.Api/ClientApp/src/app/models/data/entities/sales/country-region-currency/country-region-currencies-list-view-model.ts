import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICountryRegionCurrencySummary } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-summary';
import { ICountryRegionCurrencyLookupModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-lookup-model';

export interface ICountryRegionCurrenciesListViewModel {
  countryRegionCurrencies?: Array<ICountryRegionCurrencyLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICountryRegionCurrencySummary;
  };
}
