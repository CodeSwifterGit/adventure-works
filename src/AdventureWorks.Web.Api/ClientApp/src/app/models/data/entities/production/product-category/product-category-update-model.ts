
export interface IProductCategoryUpdateModel {
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductCategoryUpdateModel implements IProductCategoryUpdateModel {
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductCategoryUpdateModel>) {
    if (!!init) {
      Object.assign<ProductCategoryUpdateModel, Partial<ProductCategoryUpdateModel>>(this, init);
    }
  }
}
