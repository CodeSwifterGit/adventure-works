import { ICountryRegionCurrencyLookupModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-lookup-model';
import { IStateProvinceLookupModel } from 'app/models/data/entities/person/state-province/state-province-lookup-model';

export interface ICountryRegionLookupModel {
  countryRegionCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CountryRegionLookupModel implements ICountryRegionLookupModel {
  countryRegionCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CountryRegionLookupModel>) {
    if (!!init) {
      Object.assign<CountryRegionLookupModel, Partial<CountryRegionLookupModel>>(this, init);
    }
  }
}
