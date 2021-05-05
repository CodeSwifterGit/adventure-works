import { IContactCreditCardUpdateModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-update-model';
import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';
import { IIndividualUpdateModel } from 'app/models/data/entities/sales/individual/individual-update-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { IStoreContactUpdateModel } from 'app/models/data/entities/sales/store-contact/store-contact-update-model';
import { IVendorContactUpdateModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-update-model';

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
