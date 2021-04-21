import { IContactCreditCardLookupModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-lookup-model';
import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';
import { IIndividualLookupModel } from 'app/models/data/entities/sales/individual/individual-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { IStoreContactLookupModel } from 'app/models/data/entities/sales/store-contact/store-contact-lookup-model';
import { IVendorContactLookupModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-lookup-model';

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
  passwordHash: string;
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
  passwordHash: string;
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
