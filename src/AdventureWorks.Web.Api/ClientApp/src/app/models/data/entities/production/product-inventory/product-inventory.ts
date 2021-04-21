export interface IProductInventory {
  productID: number;
  locationID: number;
  shelf: string;
  bin: number;
  quantity: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class ProductInventory implements IProductInventory {
  productID: number;
  locationID: number;
  shelf: string;
  bin: number;
  quantity: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductInventory>) {
    if (!!init) {
      Object.assign<ProductInventory, Partial<ProductInventory>>(this, init);
    }
  }
}
