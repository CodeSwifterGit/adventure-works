export interface IJobCandidate {
  jobCandidateID: number;
  employeeID: number | null;
  resume: string;
  modifiedDate: Date | string;
}

export class JobCandidate implements IJobCandidate {
  jobCandidateID: number;
  employeeID: number | null;
  resume: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<JobCandidate>) {
    if (!!init) {
      Object.assign<JobCandidate, Partial<JobCandidate>>(this, init);
    }
  }
}
