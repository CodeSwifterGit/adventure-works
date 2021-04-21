import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IIllustrationSummary } from 'app/models/data/entities/production/illustration/illustration-summary';
import { IIllustrationLookupModel } from 'app/models/data/entities/production/illustration/illustration-lookup-model';

export interface IIllustrationsListViewModel {
  illustrations?: Array<IIllustrationLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IIllustrationSummary;
  };
}
