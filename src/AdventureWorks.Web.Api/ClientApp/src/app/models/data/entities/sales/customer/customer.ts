export interface ICustomer {
  customerID: number;
  territoryID: number | null;
  accountNumber: string;
  customerType: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class Customer implements ICustomer {
  customerID: number;
  territoryID: number | null;
  accountNumber: string;
  customerType: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Customer>) {
    if (!!init) {
      Object.assign<Customer, Partial<Customer>>(this, init);
    }
  }
}
