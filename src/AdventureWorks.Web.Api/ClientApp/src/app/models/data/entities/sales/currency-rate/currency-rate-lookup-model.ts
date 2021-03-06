
export interface ICurrencyRateLookupModel {
  currencyRateID: number;
  currencyRateDate: Date | string;
  fromCurrencyCode: string;
  toCurrencyCode: string;
  averageRate: number;
  endOfDayRate: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CurrencyRateLookupModel implements ICurrencyRateLookupModel {
  currencyRateID: number;
  currencyRateDate: Date | string;
  fromCurrencyCode: string;
  toCurrencyCode: string;
  averageRate: number;
  endOfDayRate: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CurrencyRateLookupModel>) {
    if (!!init) {
      Object.assign<CurrencyRateLookupModel, Partial<CurrencyRateLookupModel>>(this, init);
    }
  }
}
