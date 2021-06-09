
export interface IEmployeeDepartmentHistoryUpdateModel {
  employeeID: number;
  departmentID: number;
  shiftID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class EmployeeDepartmentHistoryUpdateModel implements IEmployeeDepartmentHistoryUpdateModel {
  employeeID: number;
  departmentID: number;
  shiftID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<EmployeeDepartmentHistoryUpdateModel>) {
    if (!!init) {
      Object.assign<EmployeeDepartmentHistoryUpdateModel, Partial<EmployeeDepartmentHistoryUpdateModel>>(this, init);
    }
  }
}
