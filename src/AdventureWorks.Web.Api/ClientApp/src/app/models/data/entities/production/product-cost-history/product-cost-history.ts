export interface IProductCostHistory {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  standardCost: number;
  modifiedDate: Date | string;
}

export class ProductCostHistory implements IProductCostHistory {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  standardCost: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductCostHistory>) {
    if (!!init) {
      Object.assign<ProductCostHistory, Partial<ProductCostHistory>>(this, init);
    }
  }
}
