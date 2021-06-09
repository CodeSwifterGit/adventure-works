import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductModel } from 'app/models/data/entities/production/product-model/product-model';
import { IProductModelLookupModel } from 'app/models/data/entities/production/product-model/product-model-lookup-model';
import { IProductModelUpdateModel } from 'app/models/data/entities/production/product-model/product-model-update-model';
import { IProductModelsListViewModel } from 'app/models/data/entities/production/product-model/product-models-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IProductModelPrimaryKey {
  productModelID: number;
}

export interface IProductModelUpdateItem extends IProductModel {
  requestTarget: IProductModelPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductModelsService {
  constructor(protected apiClient: DataService) { }

  create(model: IProductModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelLookupModel>;
  create(model: IProductModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelLookupModel>>;
  create(model: IProductModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelLookupModel>>;
  create(model: IProductModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModels', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductModel, IProductModelLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductModel>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductModelLookupModel>>;
  createMany(model: Array<IProductModel>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductModelLookupModel>>>;
  createMany(model: Array<IProductModel>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductModelLookupModel>>>;
  createMany(model: Array<IProductModel>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModels/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductModel>, Array<IProductModelLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productModelID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productModelID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productModelID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productModelID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModels', {
      productModelID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductModelPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductModelPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductModelPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductModelPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModels/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductModelPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productModelID: number, model: IProductModelUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelLookupModel>;
  update(productModelID: number, model: IProductModelUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelLookupModel>>;
  update(productModelID: number, model: IProductModelUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelLookupModel>>;
  update(productModelID: number, model: IProductModelUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModels', {
      productModelID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductModelUpdateModel, IProductModelLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductModelUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductModelLookupModel>>;
  updateMany(model: Array<IProductModelUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductModelLookupModel>>>;
  updateMany(model: Array<IProductModelUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductModelLookupModel>>>;
  updateMany(model: Array<IProductModelUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModels/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductModelUpdateItem>, Array<IProductModelLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productModelID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelLookupModel>;
  get(productModelID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelLookupModel>>;
  get(productModelID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelLookupModel>>;
  get(productModelID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModels', {
      productModelID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductModelLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModels/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IProductModelsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
