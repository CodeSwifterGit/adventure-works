
export interface IProductListPriceHistoryUpdateModel {
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

export class ProductListPriceHistoryUpdateModel implements IProductListPriceHistoryUpdateModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  listPrice: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductListPriceHistoryUpdateModel>) {
    if (!!init) {
      Object.assign<ProductListPriceHistoryUpdateModel, Partial<ProductListPriceHistoryUpdateModel>>(this, init);
    }
  }
}
