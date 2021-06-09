
export interface IProductModelUpdateModel {
  productModelID: number;
  name: string;
  catalogDescription: string;
  instructions: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductModelUpdateModel implements IProductModelUpdateModel {
  productModelID: number;
  name: string;
  catalogDescription: string;
  instructions: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductModelUpdateModel>) {
    if (!!init) {
      Object.assign<ProductModelUpdateModel, Partial<ProductModelUpdateModel>>(this, init);
    }
  }
}
