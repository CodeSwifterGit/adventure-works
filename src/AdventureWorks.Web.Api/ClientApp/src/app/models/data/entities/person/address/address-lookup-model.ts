import { ICustomerAddressLookupModel } from 'app/models/data/entities/sales/customer-address/customer-address-lookup-model';
import { IEmployeeAddressLookupModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { IStateProvinceLookupModel } from 'app/models/data/entities/person/state-province/state-province-lookup-model';
import { IVendorAddressLookupModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-lookup-model';

export interface IAddressLookupModel {
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

export class AddressLookupModel implements IAddressLookupModel {
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

  constructor(init?: Partial<AddressLookupModel>) {
    if (!!init) {
      Object.assign<AddressLookupModel, Partial<AddressLookupModel>>(this, init);
    }
  }
}
