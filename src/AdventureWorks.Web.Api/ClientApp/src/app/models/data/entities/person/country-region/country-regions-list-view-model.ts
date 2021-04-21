import { IPagingInfo } from 'app/models/data/common/paging-info';
import { ICountryRegionSummary } from 'app/models/data/entities/person/country-region/country-region-summary';
import { ICountryRegionLookupModel } from 'app/models/data/entities/person/country-region/country-region-lookup-model';

export interface ICountryRegionsListViewModel {
  countryRegions?: Array<ICountryRegionLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: ICountryRegionSummary;
  };
}
