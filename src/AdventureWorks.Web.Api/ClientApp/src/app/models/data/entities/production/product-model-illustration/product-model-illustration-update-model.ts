
export interface IProductModelIllustrationUpdateModel {
  productModelID: number;
  illustrationID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductModelIllustrationUpdateModel implements IProductModelIllustrationUpdateModel {
  productModelID: number;
  illustrationID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductModelIllustrationUpdateModel>) {
    if (!!init) {
      Object.assign<ProductModelIllustrationUpdateModel, Partial<ProductModelIllustrationUpdateModel>>(this, init);
    }
  }
}
