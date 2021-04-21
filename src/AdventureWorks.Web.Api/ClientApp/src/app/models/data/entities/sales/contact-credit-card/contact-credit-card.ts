export interface IContactCreditCard {
  contactID: number;
  creditCardID: number;
  modifiedDate: Date | string;
}

export class ContactCreditCard implements IContactCreditCard {
  contactID: number;
  creditCardID: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<ContactCreditCard>) {
    if (!!init) {
      Object.assign<ContactCreditCard, Partial<ContactCreditCard>>(this, init);
    }
  }
}
