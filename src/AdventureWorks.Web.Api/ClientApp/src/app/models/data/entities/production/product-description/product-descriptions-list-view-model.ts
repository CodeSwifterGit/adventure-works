import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductDescriptionLookupModel } from 'app/models/data/entities/production/product-description/product-description-lookup-model';
import { IProductDescriptionSummary } from 'app/models/data/entities/production/product-description/product-description-summary';

export interface IProductDescriptionsListViewModel {
  productDescriptions?: Array<IProductDescriptionLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductDescriptionSummary;
  };
}
