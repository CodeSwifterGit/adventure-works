import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { ICreditCardLookupModel } from 'app/models/data/entities/sales/credit-card/credit-card-lookup-model';

export interface IContactCreditCardLookupModel {
  contactID: number;
  creditCardID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ContactCreditCardLookupModel implements IContactCreditCardLookupModel {
  contactID: number;
  creditCardID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ContactCreditCardLookupModel>) {
    if (!!init) {
      Object.assign<ContactCreditCardLookupModel, Partial<ContactCreditCardLookupModel>>(this, init);
    }
  }
}
