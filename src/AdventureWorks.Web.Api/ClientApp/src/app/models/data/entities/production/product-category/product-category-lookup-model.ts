
export interface IProductCategoryLookupModel {
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductCategoryLookupModel implements IProductCategoryLookupModel {
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductCategoryLookupModel>) {
    if (!!init) {
      Object.assign<ProductCategoryLookupModel, Partial<ProductCategoryLookupModel>>(this, init);
    }
  }
}
