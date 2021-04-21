import { IEmployeeDepartmentHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-lookup-model';

export interface IDepartmentLookupModel {
  departmentID: number;
  name: string;
  groupName: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class DepartmentLookupModel implements IDepartmentLookupModel {
  departmentID: number;
  name: string;
  groupName: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<DepartmentLookupModel>) {
    if (!!init) {
      Object.assign<DepartmentLookupModel, Partial<DepartmentLookupModel>>(this, init);
    }
  }
}
