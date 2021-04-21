export interface ICountryRegion {
  countryRegionCode: string;
  name: string;
  modifiedDate: Date | string;
}

export class CountryRegion implements ICountryRegion {
  countryRegionCode: string;
  name: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<CountryRegion>) {
    if (!!init) {
      Object.assign<CountryRegion, Partial<CountryRegion>>(this, init);
    }
  }
}
