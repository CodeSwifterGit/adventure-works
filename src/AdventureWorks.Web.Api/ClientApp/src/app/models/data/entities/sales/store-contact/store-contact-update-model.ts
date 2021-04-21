import { IContactTypeUpdateModel } from 'app/models/data/entities/person/contact-type/contact-type-update-model';
import { IContactUpdateModel } from 'app/models/data/entities/person/contact/contact-update-model';
import { IStoreUpdateModel } from 'app/models/data/entities/sales/store/store-update-model';

export interface IStoreContactUpdateModel {
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

export class StoreContactUpdateModel implements IStoreContactUpdateModel {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<StoreContactUpdateModel>) {
    if (!!init) {
      Object.assign<StoreContactUpdateModel, Partial<StoreContactUpdateModel>>(this, init);
    }
  }
}
