import { ICustomerAddressUpdateModel } from 'app/models/data/entities/sales/customer-address/customer-address-update-model';
import { IEmployeeAddressUpdateModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-update-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { IStateProvinceUpdateModel } from 'app/models/data/entities/person/state-province/state-province-update-model';
import { IVendorAddressUpdateModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-update-model';

export interface IAddressUpdateModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  stateProvinceID: number;
  postalCode: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class AddressUpdateModel implements IAddressUpdateModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  stateProvinceID: number;
  postalCode: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<AddressUpdateModel>) {
    if (!!init) {
      Object.assign<AddressUpdateModel, Partial<AddressUpdateModel>>(this, init);
    }
  }
}
