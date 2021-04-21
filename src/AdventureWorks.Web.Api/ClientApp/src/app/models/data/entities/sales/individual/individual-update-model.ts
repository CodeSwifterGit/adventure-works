import { IContactUpdateModel } from 'app/models/data/entities/person/contact/contact-update-model';
import { ICustomerUpdateModel } from 'app/models/data/entities/sales/customer/customer-update-model';

export interface IIndividualUpdateModel {
  customerID: number;
  contactID: number;
  demographics: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class IndividualUpdateModel implements IIndividualUpdateModel {
  customerID: number;
  contactID: number;
  demographics: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<IndividualUpdateModel>) {
    if (!!init) {
      Object.assign<IndividualUpdateModel, Partial<IndividualUpdateModel>>(this, init);
    }
  }
}
