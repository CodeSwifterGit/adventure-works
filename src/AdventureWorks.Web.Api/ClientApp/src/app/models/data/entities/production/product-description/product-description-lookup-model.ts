import { IProductModelProductDescriptionCultureLookupModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-lookup-model';

export interface IProductDescriptionLookupModel {
  productDescriptionID: number;
  description: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductDescriptionLookupModel implements IProductDescriptionLookupModel {
  productDescriptionID: number;
  description: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductDescriptionLookupModel>) {
    if (!!init) {
      Object.assign<ProductDescriptionLookupModel, Partial<ProductDescriptionLookupModel>>(this, init);
    }
  }
}
