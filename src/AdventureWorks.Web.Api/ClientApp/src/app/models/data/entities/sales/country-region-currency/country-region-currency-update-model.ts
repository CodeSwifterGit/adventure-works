
export interface ICountryRegionCurrencyUpdateModel {
  countryRegionCode: string;
  currencyCode: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CountryRegionCurrencyUpdateModel implements ICountryRegionCurrencyUpdateModel {
  countryRegionCode: string;
  currencyCode: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CountryRegionCurrencyUpdateModel>) {
    if (!!init) {
      Object.assign<CountryRegionCurrencyUpdateModel, Partial<CountryRegionCurrencyUpdateModel>>(this, init);
    }
  }
}
