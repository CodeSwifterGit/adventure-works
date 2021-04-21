export interface IProductCategory {
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class ProductCategory implements IProductCategory {
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductCategory>) {
    if (!!init) {
      Object.assign<ProductCategory, Partial<ProductCategory>>(this, init);
    }
  }
}
