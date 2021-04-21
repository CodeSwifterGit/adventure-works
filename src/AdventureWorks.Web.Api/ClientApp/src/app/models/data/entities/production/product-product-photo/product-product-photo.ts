export interface IProductProductPhoto {
  productID: number;
  productPhotoID: number;
  primary: boolean;
  modifiedDate: Date | string;
}

export class ProductProductPhoto implements IProductProductPhoto {
  productID: number;
  productPhotoID: number;
  primary: boolean;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductProductPhoto>) {
    if (!!init) {
      Object.assign<ProductProductPhoto, Partial<ProductProductPhoto>>(this, init);
    }
  }
}
