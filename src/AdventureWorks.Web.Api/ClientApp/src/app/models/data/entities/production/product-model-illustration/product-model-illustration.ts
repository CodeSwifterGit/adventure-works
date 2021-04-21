export interface IProductModelIllustration {
  productModelID: number;
  illustrationID: number;
  modifiedDate: Date | string;
}

export class ProductModelIllustration implements IProductModelIllustration {
  productModelID: number;
  illustrationID: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductModelIllustration>) {
    if (!!init) {
      Object.assign<ProductModelIllustration, Partial<ProductModelIllustration>>(this, init);
    }
  }
}
