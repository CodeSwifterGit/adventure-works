import { ICustomerAddressUpdateModel } from 'app/models/data/entities/sales/customer-address/customer-address-update-model';
import { IVendorAddressUpdateModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-update-model';

export interface IAddressTypeUpdateModel {
  addressTypeID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class AddressTypeUpdateModel implements IAddressTypeUpdateModel {
  addressTypeID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<AddressTypeUpdateModel>) {
    if (!!init) {
      Object.assign<AddressTypeUpdateModel, Partial<AddressTypeUpdateModel>>(this, init);
    }
  }
}
