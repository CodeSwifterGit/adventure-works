import { IDepartmentLookupModel } from 'app/models/data/entities/human-resources/department/department-lookup-model';
import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';
import { IShiftLookupModel } from 'app/models/data/entities/human-resources/shift/shift-lookup-model';

export interface IEmployeeDepartmentHistoryLookupModel {
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

export class EmployeeDepartmentHistoryLookupModel implements IEmployeeDepartmentHistoryLookupModel {
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

  constructor(init?: Partial<EmployeeDepartmentHistoryLookupModel>) {
    if (!!init) {
      Object.assign<EmployeeDepartmentHistoryLookupModel, Partial<EmployeeDepartmentHistoryLookupModel>>(this, init);
    }
  }
}
