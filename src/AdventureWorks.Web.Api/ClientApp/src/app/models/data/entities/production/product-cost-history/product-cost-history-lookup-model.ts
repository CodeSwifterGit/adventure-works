
export interface IProductCostHistoryLookupModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  standardCost: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductCostHistoryLookupModel implements IProductCostHistoryLookupModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  standardCost: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductCostHistoryLookupModel>) {
    if (!!init) {
      Object.assign<ProductCostHistoryLookupModel, Partial<ProductCostHistoryLookupModel>>(this, init);
    }
  }
}
