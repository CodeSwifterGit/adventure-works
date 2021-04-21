import { IProductProductPhotoLookupModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-lookup-model';

export interface IProductPhotoLookupModel {
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

export class ProductPhotoLookupModel implements IProductPhotoLookupModel {
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

  constructor(init?: Partial<ProductPhotoLookupModel>) {
    if (!!init) {
      Object.assign<ProductPhotoLookupModel, Partial<ProductPhotoLookupModel>>(this, init);
    }
  }
}
