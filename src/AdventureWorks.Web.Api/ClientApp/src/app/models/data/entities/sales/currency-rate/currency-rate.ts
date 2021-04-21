export interface ICurrencyRate {
  currencyRateID: number;
  currencyRateDate: Date | string;
  fromCurrencyCode: string;
  toCurrencyCode: string;
  averageRate: number;
  endOfDayRate: number;
  modifiedDate: Date | string;
}

export class CurrencyRate implements ICurrencyRate {
  currencyRateID: number;
  currencyRateDate: Date | string;
  fromCurrencyCode: string;
  toCurrencyCode: string;
  averageRate: number;
  endOfDayRate: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<CurrencyRate>) {
    if (!!init) {
      Object.assign<CurrencyRate, Partial<CurrencyRate>>(this, init);
    }
  }
}
