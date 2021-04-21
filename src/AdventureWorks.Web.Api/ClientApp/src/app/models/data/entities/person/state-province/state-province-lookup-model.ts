import { IAddressLookupModel } from 'app/models/data/entities/person/address/address-lookup-model';
import { ICountryRegionLookupModel } from 'app/models/data/entities/person/country-region/country-region-lookup-model';
import { ISalesTaxRateLookupModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-lookup-model';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';

export interface IStateProvinceLookupModel {
  stateProvinceID: number;
  stateProvinceCode: string;
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  name: string;
  territoryID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class StateProvinceLookupModel implements IStateProvinceLookupModel {
  stateProvinceID: number;
  stateProvinceCode: string;
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  name: string;
  territoryID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<StateProvinceLookupModel>) {
    if (!!init) {
      Object.assign<StateProvinceLookupModel, Partial<StateProvinceLookupModel>>(this, init);
    }
  }
}
