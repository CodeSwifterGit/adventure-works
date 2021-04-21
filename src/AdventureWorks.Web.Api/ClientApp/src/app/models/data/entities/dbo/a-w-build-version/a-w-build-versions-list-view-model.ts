import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IAWBuildVersionSummary } from 'app/models/data/entities/dbo/a-w-build-version/a-w-build-version-summary';
import { IAWBuildVersionLookupModel } from 'app/models/data/entities/dbo/a-w-build-version/a-w-build-version-lookup-model';

export interface IAWBuildVersionsListViewModel {
  aWBuildVersions?: Array<IAWBuildVersionLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IAWBuildVersionSummary;
  };
}
