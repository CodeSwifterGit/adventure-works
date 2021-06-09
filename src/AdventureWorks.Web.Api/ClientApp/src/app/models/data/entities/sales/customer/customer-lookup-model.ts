
export interface ICustomerLookupModel {
  customerID: number;
  territoryID: number | null;
  accountNumber: string;
  customerType: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CustomerLookupModel implements ICustomerLookupModel {
  customerID: number;
  territoryID: number | null;
  accountNumber: string;
  customerType: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CustomerLookupModel>) {
    if (!!init) {
      Object.assign<CustomerLookupModel, Partial<CustomerLookupModel>>(this, init);
    }
  }
}
