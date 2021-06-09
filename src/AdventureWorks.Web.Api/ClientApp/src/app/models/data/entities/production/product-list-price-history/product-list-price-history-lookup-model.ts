
export interface IProductListPriceHistoryLookupModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  listPrice: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductListPriceHistoryLookupModel implements IProductListPriceHistoryLookupModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  listPrice: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductListPriceHistoryLookupModel>) {
    if (!!init) {
      Object.assign<ProductListPriceHistoryLookupModel, Partial<ProductListPriceHistoryLookupModel>>(this, init);
    }
  }
}
