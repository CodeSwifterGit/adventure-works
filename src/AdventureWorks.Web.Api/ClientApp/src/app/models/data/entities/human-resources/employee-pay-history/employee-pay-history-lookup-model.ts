
export interface IEmployeePayHistoryLookupModel {
  employeeID: number;
  rateChangeDate: Date | string;
  rate: number;
  payFrequency: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class EmployeePayHistoryLookupModel implements IEmployeePayHistoryLookupModel {
  employeeID: number;
  rateChangeDate: Date | string;
  rate: number;
  payFrequency: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<EmployeePayHistoryLookupModel>) {
    if (!!init) {
      Object.assign<EmployeePayHistoryLookupModel, Partial<EmployeePayHistoryLookupModel>>(this, init);
    }
  }
}
