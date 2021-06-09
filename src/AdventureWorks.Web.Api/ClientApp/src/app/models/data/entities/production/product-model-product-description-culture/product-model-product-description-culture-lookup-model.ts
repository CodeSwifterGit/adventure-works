
export interface IProductModelProductDescriptionCultureLookupModel {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductModelProductDescriptionCultureLookupModel implements IProductModelProductDescriptionCultureLookupModel {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductModelProductDescriptionCultureLookupModel>) {
    if (!!init) {
      Object.assign<ProductModelProductDescriptionCultureLookupModel, Partial<ProductModelProductDescriptionCultureLookupModel>>(this, init);
    }
  }
}
