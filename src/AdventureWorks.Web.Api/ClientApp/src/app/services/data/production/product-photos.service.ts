import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductPhoto } from 'app/models/data/entities/production/product-photo/product-photo';
import { IProductPhotoLookupModel } from 'app/models/data/entities/production/product-photo/product-photo-lookup-model';
import { IProductPhotoUpdateModel } from 'app/models/data/entities/production/product-photo/product-photo-update-model';
import { IProductPhotosListViewModel } from 'app/models/data/entities/production/product-photo/product-photos-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductPhotoPrimaryKey {
  productPhotoID: number;
}

export interface IProductPhotoUpdateItem extends IProductPhoto {
  requestTarget: IProductPhotoPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductPhotosService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductPhoto, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductPhotoLookupModel>;
  create(model: IProductPhoto, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductPhotoLookupModel>>;
  create(model: IProductPhoto, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductPhotoLookupModel>>;
  create(model: IProductPhoto, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductPhoto, IProductPhotoLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductPhoto>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductPhotoLookupModel>>;
  createMany(model: Array<IProductPhoto>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductPhotoLookupModel>>>;
  createMany(model: Array<IProductPhoto>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductPhotoLookupModel>>>;
  createMany(model: Array<IProductPhoto>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductPhoto>, Array<IProductPhotoLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productPhotoID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productPhotoID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productPhotoID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productPhotoID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos', {
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductPhotoPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductPhotoPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductPhotoPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductPhotoPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductPhotoPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productPhotoID: number, model: IProductPhotoUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductPhotoLookupModel>;
  update(productPhotoID: number, model: IProductPhotoUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductPhotoLookupModel>>;
  update(productPhotoID: number, model: IProductPhotoUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductPhotoLookupModel>>;
  update(productPhotoID: number, model: IProductPhotoUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos', {
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductPhotoUpdateModel, IProductPhotoLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductPhotoUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductPhotoLookupModel>>;
  updateMany(model: Array<IProductPhotoUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductPhotoLookupModel>>>;
  updateMany(model: Array<IProductPhotoUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductPhotoLookupModel>>>;
  updateMany(model: Array<IProductPhotoUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductPhotoUpdateItem>, Array<IProductPhotoLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productPhotoID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductPhotoLookupModel>;
  get(productPhotoID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductPhotoLookupModel>>;
  get(productPhotoID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductPhotoLookupModel>>;
  get(productPhotoID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos', {
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductPhotoLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductPhotosListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductPhotosListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductPhotosListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductPhotos/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IProductPhotosListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
