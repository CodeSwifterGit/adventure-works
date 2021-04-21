export interface ISalesTaxRate {
  salesTaxRateID: number;
  stateProvinceID: number;
  taxType: number;
  taxRate: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SalesTaxRate implements ISalesTaxRate {
  salesTaxRateID: number;
  stateProvinceID: number;
  taxType: number;
  taxRate: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesTaxRate>) {
    if (!!init) {
      Object.assign<SalesTaxRate, Partial<SalesTaxRate>>(this, init);
    }
  }
}
