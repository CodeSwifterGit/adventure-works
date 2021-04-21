export interface IEmployeeDepartmentHistory {
  employeeID: number;
  departmentID: number;
  shiftID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  modifiedDate: Date | string;
}

export class EmployeeDepartmentHistory implements IEmployeeDepartmentHistory {
  employeeID: number;
  departmentID: number;
  shiftID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  modifiedDate: Date | string;

  constructor(init?: Partial<EmployeeDepartmentHistory>) {
    if (!!init) {
      Object.assign<EmployeeDepartmentHistory, Partial<EmployeeDepartmentHistory>>(this, init);
    }
  }
}
