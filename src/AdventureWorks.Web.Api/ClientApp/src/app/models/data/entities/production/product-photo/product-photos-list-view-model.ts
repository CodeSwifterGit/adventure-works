import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductPhotoLookupModel } from 'app/models/data/entities/production/product-photo/product-photo-lookup-model';
import { IProductPhotoSummary } from 'app/models/data/entities/production/product-photo/product-photo-summary';

export interface IProductPhotosListViewModel {
  productPhotos?: Array<IProductPhotoLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductPhotoSummary;
  };
}
