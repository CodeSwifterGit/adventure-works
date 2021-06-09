import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductDescription } from 'app/models/data/entities/production/product-description/product-description';
import { IProductDescriptionLookupModel } from 'app/models/data/entities/production/product-description/product-description-lookup-model';
import { IProductDescriptionUpdateModel } from 'app/models/data/entities/production/product-description/product-description-update-model';
import { IProductDescriptionsListViewModel } from 'app/models/data/entities/production/product-description/product-descriptions-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IProductDescriptionPrimaryKey {
  productDescriptionID: number;
}

export interface IProductDescriptionUpdateItem extends IProductDescription {
  requestTarget: IProductDescriptionPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductDescriptionsService {
  constructor(protected apiClient: DataService) { }

  create(model: IProductDescription, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDescriptionLookupModel>;
  create(model: IProductDescription, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDescriptionLookupModel>>;
  create(model: IProductDescription, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDescriptionLookupModel>>;
  create(model: IProductDescription, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductDescription, IProductDescriptionLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductDescription>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductDescriptionLookupModel>>;
  createMany(model: Array<IProductDescription>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductDescriptionLookupModel>>>;
  createMany(model: Array<IProductDescription>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductDescriptionLookupModel>>>;
  createMany(model: Array<IProductDescription>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductDescription>, Array<IProductDescriptionLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productDescriptionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productDescriptionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productDescriptionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productDescriptionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions', {
      productDescriptionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductDescriptionPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductDescriptionPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductDescriptionPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductDescriptionPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductDescriptionPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productDescriptionID: number, model: IProductDescriptionUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDescriptionLookupModel>;
  update(productDescriptionID: number, model: IProductDescriptionUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDescriptionLookupModel>>;
  update(productDescriptionID: number, model: IProductDescriptionUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDescriptionLookupModel>>;
  update(productDescriptionID: number, model: IProductDescriptionUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions', {
      productDescriptionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductDescriptionUpdateModel, IProductDescriptionLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductDescriptionUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductDescriptionLookupModel>>;
  updateMany(model: Array<IProductDescriptionUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductDescriptionLookupModel>>>;
  updateMany(model: Array<IProductDescriptionUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductDescriptionLookupModel>>>;
  updateMany(model: Array<IProductDescriptionUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductDescriptionUpdateItem>, Array<IProductDescriptionLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productDescriptionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDescriptionLookupModel>;
  get(productDescriptionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDescriptionLookupModel>>;
  get(productDescriptionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDescriptionLookupModel>>;
  get(productDescriptionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions', {
      productDescriptionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductDescriptionLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDescriptionsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDescriptionsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDescriptionsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDescriptions/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IProductDescriptionsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
