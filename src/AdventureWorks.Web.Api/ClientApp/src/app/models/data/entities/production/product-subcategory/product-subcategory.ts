export interface IProductSubcategory {
  productSubcategoryID: number;
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class ProductSubcategory implements IProductSubcategory {
  productSubcategoryID: number;
  productCategoryID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductSubcategory>) {
    if (!!init) {
      Object.assign<ProductSubcategory, Partial<ProductSubcategory>>(this, init);
    }
  }
}
