import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';

export interface IJobCandidateUpdateModel {
  jobCandidateID: number;
  employeeID: number | null;
  resume: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class JobCandidateUpdateModel implements IJobCandidateUpdateModel {
  jobCandidateID: number;
  employeeID: number | null;
  resume: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<JobCandidateUpdateModel>) {
    if (!!init) {
      Object.assign<JobCandidateUpdateModel, Partial<JobCandidateUpdateModel>>(this, init);
    }
  }
}
