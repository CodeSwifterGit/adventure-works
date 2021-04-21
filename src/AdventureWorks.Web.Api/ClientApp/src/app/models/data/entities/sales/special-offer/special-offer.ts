export interface ISpecialOffer {
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
}

export class SpecialOffer implements ISpecialOffer {
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

  constructor(init?: Partial<SpecialOffer>) {
    if (!!init) {
      Object.assign<SpecialOffer, Partial<SpecialOffer>>(this, init);
    }
  }
}
