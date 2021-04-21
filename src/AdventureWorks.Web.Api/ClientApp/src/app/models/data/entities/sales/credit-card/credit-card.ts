export interface ICreditCard {
  creditCardID: number;
  cardType: string;
  cardNumber: string;
  expMonth: number;
  expYear: number;
  modifiedDate: Date | string;
}

export class CreditCard implements ICreditCard {
  creditCardID: number;
  cardType: string;
  cardNumber: string;
  expMonth: number;
  expYear: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<CreditCard>) {
    if (!!init) {
      Object.assign<CreditCard, Partial<CreditCard>>(this, init);
    }
  }
}
