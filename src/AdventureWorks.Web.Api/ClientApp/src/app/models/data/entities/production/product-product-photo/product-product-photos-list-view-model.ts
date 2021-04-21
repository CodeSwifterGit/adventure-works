import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IProductProductPhotoSummary } from 'app/models/data/entities/production/product-product-photo/product-product-photo-summary';
import { IProductProductPhotoLookupModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-lookup-model';

export interface IProductProductPhotosListViewModel {
  productProductPhotos?: Array<IProductProductPhotoLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IProductProductPhotoSummary;
  };
}
