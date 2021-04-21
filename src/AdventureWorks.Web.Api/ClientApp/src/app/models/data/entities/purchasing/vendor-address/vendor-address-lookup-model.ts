import { IAddressLookupModel } from 'app/models/data/entities/person/address/address-lookup-model';
import { IAddressTypeLookupModel } from 'app/models/data/entities/person/address-type/address-type-lookup-model';
import { IVendorLookupModel } from 'app/models/data/entities/purchasing/vendor/vendor-lookup-model';

export interface IVendorAddressLookupModel {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorAddressLookupModel implements IVendorAddressLookupModel {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorAddressLookupModel>) {
    if (!!init) {
      Object.assign<VendorAddressLookupModel, Partial<VendorAddressLookupModel>>(this, init);
    }
  }
}
