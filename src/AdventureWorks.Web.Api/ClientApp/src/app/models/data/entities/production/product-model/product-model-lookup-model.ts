
export interface IProductModelLookupModel {
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

export class ProductModelLookupModel implements IProductModelLookupModel {
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

  constructor(init?: Partial<ProductModelLookupModel>) {
    if (!!init) {
      Object.assign<ProductModelLookupModel, Partial<ProductModelLookupModel>>(this, init);
    }
  }
}
