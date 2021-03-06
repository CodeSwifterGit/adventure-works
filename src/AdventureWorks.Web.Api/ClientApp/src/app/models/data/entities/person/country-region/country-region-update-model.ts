
export interface ICountryRegionUpdateModel {
  countryRegionCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CountryRegionUpdateModel implements ICountryRegionUpdateModel {
  countryRegionCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CountryRegionUpdateModel>) {
    if (!!init) {
      Object.assign<CountryRegionUpdateModel, Partial<CountryRegionUpdateModel>>(this, init);
    }
  }
}
