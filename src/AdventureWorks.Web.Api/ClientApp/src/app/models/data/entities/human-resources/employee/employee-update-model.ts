import { IContactUpdateModel } from 'app/models/data/entities/person/contact/contact-update-model';
import { IEmployeeAddressUpdateModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-update-model';
import { IEmployeeDepartmentHistoryUpdateModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-update-model';
import { IEmployeePayHistoryUpdateModel } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history-update-model';
import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';
import { IJobCandidateUpdateModel } from 'app/models/data/entities/human-resources/job-candidate/job-candidate-update-model';
import { IPurchaseOrderHeaderUpdateModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-update-model';
import { ISalesPersonUpdateModel } from 'app/models/data/entities/sales/sales-person/sales-person-update-model';

export interface IEmployeeUpdateModel {
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

export class EmployeeUpdateModel implements IEmployeeUpdateModel {
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

  constructor(init?: Partial<EmployeeUpdateModel>) {
    if (!!init) {
      Object.assign<EmployeeUpdateModel, Partial<EmployeeUpdateModel>>(this, init);
    }
  }
}
