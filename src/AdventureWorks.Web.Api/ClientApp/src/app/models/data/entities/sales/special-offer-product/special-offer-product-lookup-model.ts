import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { ISalesOrderDetailLookupModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-lookup-model';
import { ISpecialOfferLookupModel } from 'app/models/data/entities/sales/special-offer/special-offer-lookup-model';

export interface ISpecialOfferProductLookupModel {
  specialOfferID: number;
  productID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SpecialOfferProductLookupModel implements ISpecialOfferProductLookupModel {
  specialOfferID: number;
  productID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SpecialOfferProductLookupModel>) {
    if (!!init) {
      Object.assign<SpecialOfferProductLookupModel, Partial<SpecialOfferProductLookupModel>>(this, init);
    }
  }
}
