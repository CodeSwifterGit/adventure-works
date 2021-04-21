export interface IProductDescription {
  productDescriptionID: number;
  description: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class ProductDescription implements IProductDescription {
  productDescriptionID: number;
  description: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductDescription>) {
    if (!!init) {
      Object.assign<ProductDescription, Partial<ProductDescription>>(this, init);
    }
  }
}
