
export interface IProductModelIllustrationLookupModel {
  productModelID: number;
  illustrationID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductModelIllustrationLookupModel implements IProductModelIllustrationLookupModel {
  productModelID: number;
  illustrationID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductModelIllustrationLookupModel>) {
    if (!!init) {
      Object.assign<ProductModelIllustrationLookupModel, Partial<ProductModelIllustrationLookupModel>>(this, init);
    }
  }
}
