
export interface IEmployeeLookupModel {
  employeeID: number;
  nationalIDNumber: string;
  contactID: number;
  loginID: string;
  managerID: number | null;
  title: string;
  birthDate: Date | string;
  maritalStatus: string;
  gender: string;
  hireDate: Date | string;
  salariedFlag: boolean;
  vacationHours: number;
  sickLeaveHours: number;
  currentFlag: boolean;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class EmployeeLookupModel implements IEmployeeLookupModel {
  employeeID: number;
  nationalIDNumber: string;
  contactID: number;
  loginID: string;
  managerID: number | null;
  title: string;
  birthDate: Date | string;
  maritalStatus: string;
  gender: string;
  hireDate: Date | string;
  salariedFlag: boolean;
  vacationHours: number;
  sickLeaveHours: number;
  currentFlag: boolean;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<EmployeeLookupModel>) {
    if (!!init) {
      Object.assign<EmployeeLookupModel, Partial<EmployeeLookupModel>>(this, init);
    }
  }
}
