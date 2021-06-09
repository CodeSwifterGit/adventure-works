
export interface IProductDocumentLookupModel {
  productID: number;
  documentID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductDocumentLookupModel implements IProductDocumentLookupModel {
  productID: number;
  documentID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductDocumentLookupModel>) {
    if (!!init) {
      Object.assign<ProductDocumentLookupModel, Partial<ProductDocumentLookupModel>>(this, init);
    }
  }
}
