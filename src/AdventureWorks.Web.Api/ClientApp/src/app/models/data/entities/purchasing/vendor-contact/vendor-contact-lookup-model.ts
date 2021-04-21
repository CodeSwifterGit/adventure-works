import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { IContactTypeLookupModel } from 'app/models/data/entities/person/contact-type/contact-type-lookup-model';
import { IVendorLookupModel } from 'app/models/data/entities/purchasing/vendor/vendor-lookup-model';

export interface IVendorContactLookupModel {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorContactLookupModel implements IVendorContactLookupModel {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorContactLookupModel>) {
    if (!!init) {
      Object.assign<VendorContactLookupModel, Partial<VendorContactLookupModel>>(this, init);
    }
  }
}
