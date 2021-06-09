
export interface IProductInventoryUpdateModel {
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

export class ProductInventoryUpdateModel implements IProductInventoryUpdateModel {
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

  constructor(init?: Partial<ProductInventoryUpdateModel>) {
    if (!!init) {
      Object.assign<ProductInventoryUpdateModel, Partial<ProductInventoryUpdateModel>>(this, init);
    }
  }
}
