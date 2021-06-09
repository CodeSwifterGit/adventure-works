import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IIndividualLookupModel } from 'app/models/data/entities/sales/individual/individual-lookup-model';
import { IIndividualSummary } from 'app/models/data/entities/sales/individual/individual-summary';

export interface IIndividualsListViewModel {
  individuals?: Array<IIndividualLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IIndividualSummary;
  };
}
