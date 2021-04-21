import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IBillOfMaterialsSummary } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-summary';
import { IBillOfMaterialsLookupModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-lookup-model';

export interface IBillOfMaterialsListViewModel {
  billOfMaterials?: Array<IBillOfMaterialsLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IBillOfMaterialsSummary;
  };
}
