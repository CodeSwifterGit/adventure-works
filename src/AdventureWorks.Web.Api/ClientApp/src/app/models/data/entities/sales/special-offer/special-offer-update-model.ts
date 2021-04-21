import { ISpecialOfferProductUpdateModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-update-model';

export interface ISpecialOfferUpdateModel {
  specialOfferID: number;
  description: string;
  discountPct: number;
  type: string;
  category: string;
  startDate: Date | string;
  endDate: Date | string;
  minQty: number;
  maxQty: number | null;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SpecialOfferUpdateModel implements ISpecialOfferUpdateModel {
  specialOfferID: number;
  description: string;
  discountPct: number;
  type: string;
  category: string;
  startDate: Date | string;
  endDate: Date | string;
  minQty: number;
  maxQty: number | null;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SpecialOfferUpdateModel>) {
    if (!!init) {
      Object.assign<SpecialOfferUpdateModel, Partial<SpecialOfferUpdateModel>>(this, init);
    }
  }
}
