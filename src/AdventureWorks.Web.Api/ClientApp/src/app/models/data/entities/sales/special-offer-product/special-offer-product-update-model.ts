import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';
import { ISalesOrderDetailUpdateModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-update-model';
import { ISpecialOfferUpdateModel } from 'app/models/data/entities/sales/special-offer/special-offer-update-model';

export interface ISpecialOfferProductUpdateModel {
  specialOfferID: number;
  productID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SpecialOfferProductUpdateModel implements ISpecialOfferProductUpdateModel {
  specialOfferID: number;
  productID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SpecialOfferProductUpdateModel>) {
    if (!!init) {
      Object.assign<SpecialOfferProductUpdateModel, Partial<SpecialOfferProductUpdateModel>>(this, init);
    }
  }
}
