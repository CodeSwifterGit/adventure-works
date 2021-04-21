import { IProductProductPhotoUpdateModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-update-model';

export interface IProductPhotoUpdateModel {
  productPhotoID: number;
  thumbNailPhoto: Int8Array;
  thumbnailPhotoFileName: string;
  largePhoto: Int8Array;
  largePhotoFileName: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductPhotoUpdateModel implements IProductPhotoUpdateModel {
  productPhotoID: number;
  thumbNailPhoto: Int8Array;
  thumbnailPhotoFileName: string;
  largePhoto: Int8Array;
  largePhotoFileName: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductPhotoUpdateModel>) {
    if (!!init) {
      Object.assign<ProductPhotoUpdateModel, Partial<ProductPhotoUpdateModel>>(this, init);
    }
  }
}
