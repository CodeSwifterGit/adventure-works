
export interface IProductInventoryLookupModel {
  productID: number;
  locationID: number;
  shelf: string;
  bin: number;
  quantity: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductInventoryLookupModel implements IProductInventoryLookupModel {
  productID: number;
  locationID: number;
  shelf: string;
  bin: number;
  quantity: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductInventoryLookupModel>) {
    if (!!init) {
      Object.assign<ProductInventoryLookupModel, Partial<ProductInventoryLookupModel>>(this, init);
    }
  }
}
