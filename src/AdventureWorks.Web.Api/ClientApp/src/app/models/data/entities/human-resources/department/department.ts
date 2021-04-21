export interface IDepartment {
  departmentID: number;
  name: string;
  groupName: string;
  modifiedDate: Date | string;
}

export class Department implements IDepartment {
  departmentID: number;
  name: string;
  groupName: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Department>) {
    if (!!init) {
      Object.assign<Department, Partial<Department>>(this, init);
    }
  }
}
