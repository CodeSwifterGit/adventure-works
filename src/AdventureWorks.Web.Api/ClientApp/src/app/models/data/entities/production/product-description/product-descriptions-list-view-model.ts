import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductDescriptionSummary } from 'app/models/data/entities/production/product-description/product-description-summary';
import { IProductDescriptionLookupModel } from 'app/models/data/entities/production/product-description/product-description-lookup-model';

export interface IProductDescriptionsListViewModel {
  productDescriptions?: Array<IProductDescriptionLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductDescriptionSummary;
  };
}
