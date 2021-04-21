import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { IContactTypeLookupModel } from 'app/models/data/entities/person/contact-type/contact-type-lookup-model';
import { IStoreLookupModel } from 'app/models/data/entities/sales/store/store-lookup-model';

export interface IStoreContactLookupModel {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class StoreContactLookupModel implements IStoreContactLookupModel {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<StoreContactLookupModel>) {
    if (!!init) {
      Object.assign<StoreContactLookupModel, Partial<StoreContactLookupModel>>(this, init);
    }
  }
}
