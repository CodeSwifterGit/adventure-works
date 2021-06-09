
export interface ISpecialOfferLookupModel {
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

export class SpecialOfferLookupModel implements ISpecialOfferLookupModel {
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

  constructor(init?: Partial<SpecialOfferLookupModel>) {
    if (!!init) {
      Object.assign<SpecialOfferLookupModel, Partial<SpecialOfferLookupModel>>(this, init);
    }
  }
}
