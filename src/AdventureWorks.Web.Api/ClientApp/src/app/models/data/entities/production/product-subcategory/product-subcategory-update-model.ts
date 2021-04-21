import { IProductCategoryUpdateModel } from 'app/models/data/entities/production/product-category/product-category-update-model';
import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';

export interface IProductSubcategoryUpdateModel {
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

export class ProductSubcategoryUpdateModel implements IProductSubcategoryUpdateModel {
  productSubcategoryID: number;
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductSubcategoryUpdateModel>) {
    if (!!init) {
      Object.assign<ProductSubcategoryUpdateModel, Partial<ProductSubcategoryUpdateModel>>(this, init);
    }
  }
}
