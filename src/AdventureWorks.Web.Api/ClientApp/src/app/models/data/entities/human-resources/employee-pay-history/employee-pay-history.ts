export interface IEmployeePayHistory {
  employeeID: number;
  rateChangeDate: Date | string;
  rate: number;
  payFrequency: number;
  modifiedDate: Date | string;
}

export class EmployeePayHistory implements IEmployeePayHistory {
  employeeID: number;
  rateChangeDate: Date | string;
  rate: number;
  payFrequency: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<EmployeePayHistory>) {
    if (!!init) {
      Object.assign<EmployeePayHistory, Partial<EmployeePayHistory>>(this, init);
    }
  }
}
