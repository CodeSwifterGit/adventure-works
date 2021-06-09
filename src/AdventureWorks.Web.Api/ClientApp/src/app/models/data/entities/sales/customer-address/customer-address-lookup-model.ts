
export interface ICustomerAddressLookupModel {
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

export class CustomerAddressLookupModel implements ICustomerAddressLookupModel {
  customerID: number;
  addressID: number;
  addressTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CustomerAddressLookupModel>) {
    if (!!init) {
      Object.assign<CustomerAddressLookupModel, Partial<CustomerAddressLookupModel>>(this, init);
    }
  }
}
