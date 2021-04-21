import { IEmployeeDepartmentHistoryUpdateModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-update-model';

export interface IDepartmentUpdateModel {
  departmentID: number;
  name: string;
  groupName: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class DepartmentUpdateModel implements IDepartmentUpdateModel {
  departmentID: number;
  name: string;
  groupName: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<DepartmentUpdateModel>) {
    if (!!init) {
      Object.assign<DepartmentUpdateModel, Partial<DepartmentUpdateModel>>(this, init);
    }
  }
}
