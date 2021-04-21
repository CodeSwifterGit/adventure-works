export interface IProductModel {
  productModelID: number;
  name: string;
  catalogDescription: string;
  instructions: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class ProductModel implements IProductModel {
  productModelID: number;
  name: string;
  catalogDescription: string;
  instructions: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductModel>) {
    if (!!init) {
      Object.assign<ProductModel, Partial<ProductModel>>(this, init);
    }
  }
}
