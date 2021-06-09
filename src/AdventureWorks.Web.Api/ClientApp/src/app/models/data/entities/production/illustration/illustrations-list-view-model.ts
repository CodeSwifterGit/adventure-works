import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IIllustrationLookupModel } from 'app/models/data/entities/production/illustration/illustration-lookup-model';
import { IIllustrationSummary } from 'app/models/data/entities/production/illustration/illustration-summary';

export interface IIllustrationsListViewModel {
  illustrations?: Array<IIllustrationLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IIllustrationSummary;
  };
}
