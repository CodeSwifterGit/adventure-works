import { IAddressTypeUpdateModel } from 'app/models/data/entities/person/address-type/address-type-update-model';
import { IAddressUpdateModel } from 'app/models/data/entities/person/address/address-update-model';
import { ICustomerUpdateModel } from 'app/models/data/entities/sales/customer/customer-update-model';

export interface ICustomerAddressUpdateModel {
  customerID: number;
  addressID: number;
  addressTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CustomerAddressUpdateModel implements ICustomerAddressUpdateModel {
  customerID: number;
  addressID: number;
  addressTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CustomerAddressUpdateModel>) {
    if (!!init) {
      Object.assign<CustomerAddressUpdateModel, Partial<CustomerAddressUpdateModel>>(this, init);
    }
  }
}
