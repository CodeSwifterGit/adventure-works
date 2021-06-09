
export interface IJobCandidateLookupModel {
  jobCandidateID: number;
  employeeID: number | null;
  resume: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class JobCandidateLookupModel implements IJobCandidateLookupModel {
  jobCandidateID: number;
  employeeID: number | null;
  resume: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<JobCandidateLookupModel>) {
    if (!!init) {
      Object.assign<JobCandidateLookupModel, Partial<JobCandidateLookupModel>>(this, init);
    }
  }
}
