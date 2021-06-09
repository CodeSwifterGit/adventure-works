
export interface IContactUpdateModel {
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

export class ContactUpdateModel implements IContactUpdateModel {
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

  constructor(init?: Partial<ContactUpdateModel>) {
    if (!!init) {
      Object.assign<ContactUpdateModel, Partial<ContactUpdateModel>>(this, init);
    }
  }
}
