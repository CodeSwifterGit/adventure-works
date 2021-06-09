
export interface IProductSubcategoryLookupModel {
  productSubcategoryID: number;
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductSubcategoryLookupModel implements IProductSubcategoryLookupModel {
  productSubcategoryID: number;
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductSubcategoryLookupModel>) {
    if (!!init) {
      Object.assign<ProductSubcategoryLookupModel, Partial<ProductSubcategoryLookupModel>>(this, init);
    }
  }
}
