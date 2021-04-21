import { IProductModelProductDescriptionCultureUpdateModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-update-model';

export interface IProductDescriptionUpdateModel {
  productDescriptionID: number;
  description: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductDescriptionUpdateModel implements IProductDescriptionUpdateModel {
  productDescriptionID: number;
  description: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductDescriptionUpdateModel>) {
    if (!!init) {
      Object.assign<ProductDescriptionUpdateModel, Partial<ProductDescriptionUpdateModel>>(this, init);
    }
  }
}
