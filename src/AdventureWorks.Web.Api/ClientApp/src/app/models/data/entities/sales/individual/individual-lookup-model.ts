import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { ICustomerLookupModel } from 'app/models/data/entities/sales/customer/customer-lookup-model';

export interface IIndividualLookupModel {
  customerID: number;
  contactID: number;
  demographics: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class IndividualLookupModel implements IIndividualLookupModel {
  customerID: number;
  contactID: number;
  demographics: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<IndividualLookupModel>) {
    if (!!init) {
      Object.assign<IndividualLookupModel, Partial<IndividualLookupModel>>(this, init);
    }
  }
}
