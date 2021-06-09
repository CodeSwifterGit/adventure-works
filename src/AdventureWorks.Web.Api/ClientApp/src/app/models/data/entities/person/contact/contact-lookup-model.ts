
export interface IContactLookupModel {
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
  passwordSalt: string;
  additionalContactInfo: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ContactLookupModel implements IContactLookupModel {
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
  passwordSalt: string;
  additionalContactInfo: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ContactLookupModel>) {
    if (!!init) {
      Object.assign<ContactLookupModel, Partial<ContactLookupModel>>(this, init);
    }
  }
}
