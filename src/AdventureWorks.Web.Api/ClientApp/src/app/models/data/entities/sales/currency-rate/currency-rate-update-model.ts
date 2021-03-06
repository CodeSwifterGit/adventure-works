
export interface ICurrencyRateUpdateModel {
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

export class CurrencyRateUpdateModel implements ICurrencyRateUpdateModel {
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

  constructor(init?: Partial<CurrencyRateUpdateModel>) {
    if (!!init) {
      Object.assign<CurrencyRateUpdateModel, Partial<CurrencyRateUpdateModel>>(this, init);
    }
  }
}
