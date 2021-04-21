import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { IEmployeeAddressLookupModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-lookup-model';
import { IEmployeeDepartmentHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-lookup-model';
import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';
import { IEmployeePayHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history-lookup-model';
import { IJobCandidateLookupModel } from 'app/models/data/entities/human-resources/job-candidate/job-candidate-lookup-model';
import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';
import { ISalesPersonLookupModel } from 'app/models/data/entities/sales/sales-person/sales-person-lookup-model';

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
