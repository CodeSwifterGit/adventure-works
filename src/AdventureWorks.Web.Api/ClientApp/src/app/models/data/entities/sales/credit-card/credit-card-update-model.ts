import { IContactCreditCardUpdateModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-update-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';

export interface ICreditCardUpdateModel {
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

export class CreditCardUpdateModel implements ICreditCardUpdateModel {
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

  constructor(init?: Partial<CreditCardUpdateModel>) {
    if (!!init) {
      Object.assign<CreditCardUpdateModel, Partial<CreditCardUpdateModel>>(this, init);
    }
  }
}
