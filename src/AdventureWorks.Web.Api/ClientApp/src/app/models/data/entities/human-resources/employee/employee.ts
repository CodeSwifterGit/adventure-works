export interface IEmployee {
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
}

export class Employee implements IEmployee {
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

  constructor(init?: Partial<Employee>) {
    if (!!init) {
      Object.assign<Employee, Partial<Employee>>(this, init);
    }
  }
}
