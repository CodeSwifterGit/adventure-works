export interface ICustomerAddress {
  customerID: number;
  addressID: number;
  addressTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class CustomerAddress implements ICustomerAddress {
  customerID: number;
  addressID: number;
  addressTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<CustomerAddress>) {
    if (!!init) {
      Object.assign<CustomerAddress, Partial<CustomerAddress>>(this, init);
    }
  }
}
