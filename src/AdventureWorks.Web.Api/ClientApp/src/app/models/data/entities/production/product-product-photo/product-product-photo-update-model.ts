import { IProductPhotoUpdateModel } from 'app/models/data/entities/production/product-photo/product-photo-update-model';
import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';

export interface IProductProductPhotoUpdateModel {
  productID: number;
  productPhotoID: number;
  primary: boolean;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductProductPhotoUpdateModel implements IProductProductPhotoUpdateModel {
  productID: number;
  productPhotoID: number;
  primary: boolean;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductProductPhotoUpdateModel>) {
    if (!!init) {
      Object.assign<ProductProductPhotoUpdateModel, Partial<ProductProductPhotoUpdateModel>>(this, init);
    }
  }
}
