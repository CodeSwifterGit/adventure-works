export interface IProduct {
  productID: number;
  name: string;
  productNumber: string;
  makeFlag: boolean;
  finishedGoodsFlag: boolean;
  color: string;
  safetyStockLevel: number;
  reorderPoint: number;
  standardCost: number;
  listPrice: number;
  size: string;
  sizeUnitMeasureCode: string;
  weightUnitMeasureCode: string;
  weight: number | null;
  daysToManufacture: number;
  productLine: string;
  class: string;
  style: string;
  productSubcategoryID: number | null;
  productModelID: number | null;
  sellStartDate: Date | string;
  sellEndDate: Date | string | null;
  discontinuedDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;
}

export class Product implements IProduct {
  productID: number;
  name: string;
  productNumber: string;
  makeFlag: boolean;
  finishedGoodsFlag: boolean;
  color: string;
  safetyStockLevel: number;
  reorderPoint: number;
  standardCost: number;
  listPrice: number;
  size: string;
  sizeUnitMeasureCode: string;
  weightUnitMeasureCode: string;
  weight: number | null;
  daysToManufacture: number;
  productLine: string;
  class: string;
  style: string;
  productSubcategoryID: number | null;
  productModelID: number | null;
  sellStartDate: Date | string;
  sellEndDate: Date | string | null;
  discontinuedDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Product>) {
    if (!!init) {
      Object.assign<Product, Partial<Product>>(this, init);
    }
  }
}
