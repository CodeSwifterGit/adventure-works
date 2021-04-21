export interface ISpecialOfferProduct {
  specialOfferID: number;
  productID: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SpecialOfferProduct implements ISpecialOfferProduct {
  specialOfferID: number;
  productID: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SpecialOfferProduct>) {
    if (!!init) {
      Object.assign<SpecialOfferProduct, Partial<SpecialOfferProduct>>(this, init);
    }
  }
}
