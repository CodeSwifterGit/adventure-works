export interface ICountryRegionCurrency {
  countryRegionCode: string;
  currencyCode: string;
  modifiedDate: Date | string;
}

export class CountryRegionCurrency implements ICountryRegionCurrency {
  countryRegionCode: string;
  currencyCode: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<CountryRegionCurrency>) {
    if (!!init) {
      Object.assign<CountryRegionCurrency, Partial<CountryRegionCurrency>>(this, init);
    }
  }
}
