
export interface IEmployeeAddressUpdateModel {
  employeeID: number;
  addressID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class EmployeeAddressUpdateModel implements IEmployeeAddressUpdateModel {
  employeeID: number;
  addressID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<EmployeeAddressUpdateModel>) {
    if (!!init) {
      Object.assign<EmployeeAddressUpdateModel, Partial<EmployeeAddressUpdateModel>>(this, init);
    }
  }
}
