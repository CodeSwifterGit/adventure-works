export interface IEmployeeAddress {
  employeeID: number;
  addressID: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class EmployeeAddress implements IEmployeeAddress {
  employeeID: number;
  addressID: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<EmployeeAddress>) {
    if (!!init) {
      Object.assign<EmployeeAddress, Partial<EmployeeAddress>>(this, init);
    }
  }
}
