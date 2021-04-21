import { IAddressUpdateModel } from 'app/models/data/entities/person/address/address-update-model';
import { ICountryRegionUpdateModel } from 'app/models/data/entities/person/country-region/country-region-update-model';
import { ISalesTaxRateUpdateModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-update-model';
import { ISalesTerritoryUpdateModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-update-model';

export interface IStateProvinceUpdateModel {
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

export class StateProvinceUpdateModel implements IStateProvinceUpdateModel {
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

  constructor(init?: Partial<StateProvinceUpdateModel>) {
    if (!!init) {
      Object.assign<StateProvinceUpdateModel, Partial<StateProvinceUpdateModel>>(this, init);
    }
  }
}
