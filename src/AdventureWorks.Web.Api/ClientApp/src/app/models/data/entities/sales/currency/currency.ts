export interface ICurrency {
  currencyCode: string;
  name: string;
  modifiedDate: Date | string;
}

export class Currency implements ICurrency {
  currencyCode: string;
  name: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Currency>) {
    if (!!init) {
      Object.assign<Currency, Partial<Currency>>(this, init);
    }
  }
}
