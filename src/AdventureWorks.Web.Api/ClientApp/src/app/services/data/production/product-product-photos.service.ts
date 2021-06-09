import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductProductPhoto } from 'app/models/data/entities/production/product-product-photo/product-product-photo';
import { IProductProductPhotoLookupModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-lookup-model';
import { IProductProductPhotoUpdateModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-update-model';
import { IProductProductPhotosListViewModel } from 'app/models/data/entities/production/product-product-photo/product-product-photos-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IProductProductPhotoPrimaryKey {
  productID: number;
  productPhotoID: number;
}

export interface IProductProductPhotoUpdateItem extends IProductProductPhoto {
  requestTarget: IProductProductPhotoPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductProductPhotosService {
  constructor(protected apiClient: DataService) { }

  create(model: IProductProductPhoto, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductProductPhotoLookupModel>;
  create(model: IProductProductPhoto, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductProductPhotoLookupModel>>;
  create(model: IProductProductPhoto, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductProductPhotoLookupModel>>;
  create(model: IProductProductPhoto, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductProductPhoto, IProductProductPhotoLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductProductPhoto>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductProductPhotoLookupModel>>;
  createMany(model: Array<IProductProductPhoto>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductProductPhotoLookupModel>>>;
  createMany(model: Array<IProductProductPhoto>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductProductPhotoLookupModel>>>;
  createMany(model: Array<IProductProductPhoto>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductProductPhoto>, Array<IProductProductPhotoLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, productPhotoID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, productPhotoID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, productPhotoID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, productPhotoID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos', {
      productID,
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductProductPhotoPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductProductPhotoPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductProductPhotoPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductProductPhotoPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductProductPhotoPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, productPhotoID: number, model: IProductProductPhotoUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductProductPhotoLookupModel>;
  update(productID: number, productPhotoID: number, model: IProductProductPhotoUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductProductPhotoLookupModel>>;
  update(productID: number, productPhotoID: number, model: IProductProductPhotoUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductProductPhotoLookupModel>>;
  update(productID: number, productPhotoID: number, model: IProductProductPhotoUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos', {
      productID,
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductProductPhotoUpdateModel, IProductProductPhotoLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductProductPhotoUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductProductPhotoLookupModel>>;
  updateMany(model: Array<IProductProductPhotoUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductProductPhotoLookupModel>>>;
  updateMany(model: Array<IProductProductPhotoUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductProductPhotoLookupModel>>>;
  updateMany(model: Array<IProductProductPhotoUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductProductPhotoUpdateItem>, Array<IProductProductPhotoLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, productPhotoID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductProductPhotoLookupModel>;
  get(productID: number, productPhotoID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductProductPhotoLookupModel>>;
  get(productID: number, productPhotoID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductProductPhotoLookupModel>>;
  get(productID: number, productPhotoID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos', {
      productID,
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductProductPhotoLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductProductPhotosListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductProductPhotosListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductProductPhotosListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos/GetProductProductPhotosByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductProductPhotosListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProductPhoto(productPhotoID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductProductPhotosListViewModel>;
  getByProductPhoto(productPhotoID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductProductPhotosListViewModel>>;
  getByProductPhoto(productPhotoID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductProductPhotosListViewModel>>;
  getByProductPhoto(productPhotoID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductProductPhotos/GetProductProductPhotosByProductPhoto', {
      productPhotoID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductProductPhotosListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
