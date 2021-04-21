export interface IContact {
  contactID: number;
  nameStyle: boolean;
  title: string;
  firstName: string;
  middleName: string;
  lastName: string;
  suffix: string;
  emailAddress: string;
  emailPromotion: number;
  phone: string;
  passwordHash: string;
  passwordSalt: string;
  additionalContactInfo: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class Contact implements IContact {
  contactID: number;
  nameStyle: boolean;
  title: string;
  firstName: string;
  middleName: string;
  lastName: string;
  suffix: string;
  emailAddress: string;
  emailPromotion: number;
  phone: string;
  passwordHash: string;
  passwordSalt: string;
  additionalContactInfo: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Contact>) {
    if (!!init) {
      Object.assign<Contact, Partial<Contact>>(this, init);
    }
  }
}
