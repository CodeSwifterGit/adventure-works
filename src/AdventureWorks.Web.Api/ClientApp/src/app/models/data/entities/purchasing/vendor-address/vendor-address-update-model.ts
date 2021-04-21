import { IAddressTypeUpdateModel } from 'app/models/data/entities/person/address-type/address-type-update-model';
import { IAddressUpdateModel } from 'app/models/data/entities/person/address/address-update-model';
import { IVendorUpdateModel } from 'app/models/data/entities/purchasing/vendor/vendor-update-model';

export interface IVendorAddressUpdateModel {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorAddressUpdateModel implements IVendorAddressUpdateModel {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorAddressUpdateModel>) {
    if (!!init) {
      Object.assign<VendorAddressUpdateModel, Partial<VendorAddressUpdateModel>>(this, init);
    }
  }
}
