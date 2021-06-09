
export interface IProductUpdateModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductUpdateModel implements IProductUpdateModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductUpdateModel>) {
    if (!!init) {
      Object.assign<ProductUpdateModel, Partial<ProductUpdateModel>>(this, init);
    }
  }
}
