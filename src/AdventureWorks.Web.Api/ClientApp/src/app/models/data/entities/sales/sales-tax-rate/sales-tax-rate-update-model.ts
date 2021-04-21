import { IStateProvinceUpdateModel } from 'app/models/data/entities/person/state-province/state-province-update-model';

export interface ISalesTaxRateUpdateModel {
  salesTaxRateID: number;
  stateProvinceID: number;
  taxType: number;
  taxRate: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesTaxRateUpdateModel implements ISalesTaxRateUpdateModel {
  salesTaxRateID: number;
  stateProvinceID: number;
  taxType: number;
  taxRate: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesTaxRateUpdateModel>) {
    if (!!init) {
      Object.assign<SalesTaxRateUpdateModel, Partial<SalesTaxRateUpdateModel>>(this, init);
    }
  }
}
