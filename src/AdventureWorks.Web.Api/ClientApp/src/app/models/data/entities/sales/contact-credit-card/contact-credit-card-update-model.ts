import { IContactUpdateModel } from 'app/models/data/entities/person/contact/contact-update-model';
import { ICreditCardUpdateModel } from 'app/models/data/entities/sales/credit-card/credit-card-update-model';

export interface IContactCreditCardUpdateModel {
  contactID: number;
  creditCardID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ContactCreditCardUpdateModel implements IContactCreditCardUpdateModel {
  contactID: number;
  creditCardID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ContactCreditCardUpdateModel>) {
    if (!!init) {
      Object.assign<ContactCreditCardUpdateModel, Partial<ContactCreditCardUpdateModel>>(this, init);
    }
  }
}
