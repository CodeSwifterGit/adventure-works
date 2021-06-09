import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IJobCandidateLookupModel } from 'app/models/data/entities/human-resources/job-candidate/job-candidate-lookup-model';
import { IJobCandidateSummary } from 'app/models/data/entities/human-resources/job-candidate/job-candidate-summary';

export interface IJobCandidatesListViewModel {
  jobCandidates?: Array<IJobCandidateLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IJobCandidateSummary;
  };
}
