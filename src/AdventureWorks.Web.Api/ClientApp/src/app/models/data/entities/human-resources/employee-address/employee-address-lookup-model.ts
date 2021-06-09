
export interface IEmployeeAddressLookupModel {
  employeeID: number;
  addressID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class EmployeeAddressLookupModel implements IEmployeeAddressLookupModel {
  employeeID: number;
  addressID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<EmployeeAddressLookupModel>) {
    if (!!init) {
      Object.assign<EmployeeAddressLookupModel, Partial<EmployeeAddressLookupModel>>(this, init);
    }
  }
}
