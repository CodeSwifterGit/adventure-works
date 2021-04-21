import { IDocumentUpdateModel } from 'app/models/data/entities/production/document/document-update-model';
import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';

export interface IProductDocumentUpdateModel {
  productID: number;
  documentID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductDocumentUpdateModel implements IProductDocumentUpdateModel {
  productID: number;
  documentID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductDocumentUpdateModel>) {
    if (!!init) {
      Object.assign<ProductDocumentUpdateModel, Partial<ProductDocumentUpdateModel>>(this, init);
    }
  }
}
