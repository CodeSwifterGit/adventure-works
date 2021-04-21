export interface IProductPhoto {
  productPhotoID: number;
  thumbNailPhoto: Int8Array;
  thumbnailPhotoFileName: string;
  largePhoto: Int8Array;
  largePhotoFileName: string;
  modifiedDate: Date | string;
}

export class ProductPhoto implements IProductPhoto {
  productPhotoID: number;
  thumbNailPhoto: Int8Array;
  thumbnailPhotoFileName: string;
  largePhoto: Int8Array;
  largePhotoFileName: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductPhoto>) {
    if (!!init) {
      Object.assign<ProductPhoto, Partial<ProductPhoto>>(this, init);
    }
  }
}
