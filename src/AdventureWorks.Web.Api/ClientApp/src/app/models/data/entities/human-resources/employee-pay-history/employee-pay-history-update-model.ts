import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';

export interface IEmployeePayHistoryUpdateModel {
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

export class EmployeePayHistoryUpdateModel implements IEmployeePayHistoryUpdateModel {
  employeeID: number;
  rateChangeDate: Date | string;
  rate: number;
  payFrequency: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<EmployeePayHistoryUpdateModel>) {
    if (!!init) {
      Object.assign<EmployeePayHistoryUpdateModel, Partial<EmployeePayHistoryUpdateModel>>(this, init);
    }
  }
}
