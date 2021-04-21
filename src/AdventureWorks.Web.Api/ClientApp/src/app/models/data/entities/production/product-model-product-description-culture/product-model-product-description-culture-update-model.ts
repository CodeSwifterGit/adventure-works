import { ICultureUpdateModel } from 'app/models/data/entities/production/culture/culture-update-model';
import { IProductDescriptionUpdateModel } from 'app/models/data/entities/production/product-description/product-description-update-model';
import { IProductModelUpdateModel } from 'app/models/data/entities/production/product-model/product-model-update-model';

export interface IProductModelProductDescriptionCultureUpdateModel {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductModelProductDescriptionCultureUpdateModel implements IProductModelProductDescriptionCultureUpdateModel {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductModelProductDescriptionCultureUpdateModel>) {
    if (!!init) {
      Object.assign<ProductModelProductDescriptionCultureUpdateModel, Partial<ProductModelProductDescriptionCultureUpdateModel>>(this, init);
    }
  }
}
