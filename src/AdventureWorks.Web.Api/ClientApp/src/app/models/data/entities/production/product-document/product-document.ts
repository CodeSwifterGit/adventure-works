export interface IProductDocument {
  productID: number;
  documentID: number;
  modifiedDate: Date | string;
}

export class ProductDocument implements IProductDocument {
  productID: number;
  documentID: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductDocument>) {
    if (!!init) {
      Object.assign<ProductDocument, Partial<ProductDocument>>(this, init);
    }
  }
}
