export interface IProductListPriceHistory {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  listPrice: number;
  modifiedDate: Date | string;
}

export class ProductListPriceHistory implements IProductListPriceHistory {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  listPrice: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductListPriceHistory>) {
    if (!!init) {
      Object.assign<ProductListPriceHistory, Partial<ProductListPriceHistory>>(this, init);
    }
  }
}
