export interface IProductModelProductDescriptionCulture {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
  modifiedDate: Date | string;
}

export class ProductModelProductDescriptionCulture implements IProductModelProductDescriptionCulture {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductModelProductDescriptionCulture>) {
    if (!!init) {
      Object.assign<ProductModelProductDescriptionCulture, Partial<ProductModelProductDescriptionCulture>>(this, init);
    }
  }
}
