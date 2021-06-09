
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
