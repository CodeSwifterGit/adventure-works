
export interface ICustomerUpdateModel {
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

export class CustomerUpdateModel implements ICustomerUpdateModel {
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

  constructor(init?: Partial<CustomerUpdateModel>) {
    if (!!init) {
      Object.assign<CustomerUpdateModel, Partial<CustomerUpdateModel>>(this, init);
    }
  }
}
