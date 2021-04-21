import { IContactCreditCardLookupModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';

export interface ICreditCardLookupModel {
  creditCardID: number;
  cardType: string;
  cardNumber: string;
  expMonth: number;
  expYear: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CreditCardLookupModel implements ICreditCardLookupModel {
  creditCardID: number;
  cardType: string;
  cardNumber: string;
  expMonth: number;
  expYear: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CreditCardLookupModel>) {
    if (!!init) {
      Object.assign<CreditCardLookupModel, Partial<CreditCardLookupModel>>(this, init);
    }
  }
}
