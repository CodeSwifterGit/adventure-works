
export interface ISalesTaxRateLookupModel {
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

export class SalesTaxRateLookupModel implements ISalesTaxRateLookupModel {
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

  constructor(init?: Partial<SalesTaxRateLookupModel>) {
    if (!!init) {
      Object.assign<SalesTaxRateLookupModel, Partial<SalesTaxRateLookupModel>>(this, init);
    }
  }
}
