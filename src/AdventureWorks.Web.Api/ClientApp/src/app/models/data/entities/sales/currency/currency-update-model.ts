import { ICountryRegionCurrencyUpdateModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-update-model';
import { ICurrencyRateUpdateModel } from 'app/models/data/entities/sales/currency-rate/currency-rate-update-model';

export interface ICurrencyUpdateModel {
  currencyCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CurrencyUpdateModel implements ICurrencyUpdateModel {
  currencyCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CurrencyUpdateModel>) {
    if (!!init) {
      Object.assign<CurrencyUpdateModel, Partial<CurrencyUpdateModel>>(this, init);
    }
  }
}
