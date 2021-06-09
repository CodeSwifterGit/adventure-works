
export interface ICountryRegionCurrencyLookupModel {
  countryRegionCode: string;
  currencyCode: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CountryRegionCurrencyLookupModel implements ICountryRegionCurrencyLookupModel {
  countryRegionCode: string;
  currencyCode: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CountryRegionCurrencyLookupModel>) {
    if (!!init) {
      Object.assign<CountryRegionCurrencyLookupModel, Partial<CountryRegionCurrencyLookupModel>>(this, init);
    }
  }
}
