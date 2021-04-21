import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IIndividualSummary } from 'app/models/data/entities/sales/individual/individual-summary';
import { IIndividualLookupModel } from 'app/models/data/entities/sales/individual/individual-lookup-model';

export interface IIndividualsListViewModel {
  individuals?: Array<IIndividualLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IIndividualSummary;
  };
}
