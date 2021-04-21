import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';

export interface IProductCostHistoryUpdateModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  standardCost: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductCostHistoryUpdateModel implements IProductCostHistoryUpdateModel {
  productID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  standardCost: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductCostHistoryUpdateModel>) {
    if (!!init) {
      Object.assign<ProductCostHistoryUpdateModel, Partial<ProductCostHistoryUpdateModel>>(this, init);
    }
  }
}
