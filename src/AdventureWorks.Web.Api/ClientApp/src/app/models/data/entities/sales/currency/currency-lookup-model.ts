
export interface ICurrencyLookupModel {
  currencyCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CurrencyLookupModel implements ICurrencyLookupModel {
  currencyCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CurrencyLookupModel>) {
    if (!!init) {
      Object.assign<CurrencyLookupModel, Partial<CurrencyLookupModel>>(this, init);
    }
  }
}
