
export interface IProductProductPhotoLookupModel {
  productID: number;
  productPhotoID: number;
  primary: boolean;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductProductPhotoLookupModel implements IProductProductPhotoLookupModel {
  productID: number;
  productPhotoID: number;
  primary: boolean;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductProductPhotoLookupModel>) {
    if (!!init) {
      Object.assign<ProductProductPhotoLookupModel, Partial<ProductProductPhotoLookupModel>>(this, init);
    }
  }
}
