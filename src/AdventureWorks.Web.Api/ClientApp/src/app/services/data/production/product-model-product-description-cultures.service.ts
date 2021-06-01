import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductModelProductDescriptionCulture } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture';
import { IProductModelProductDescriptionCultureLookupModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-lookup-model';
import { IProductModelProductDescriptionCultureUpdateModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-culture-update-model';
import { IProductModelProductDescriptionCulturesListViewModel } from 'app/models/data/entities/production/product-model-product-description-culture/product-model-product-description-cultures-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductModelProductDescriptionCulturePrimaryKey {
  productModelID: number;
  productDescriptionID: number;
  cultureID: string;
}

export interface IProductModelProductDescriptionCultureUpdateItem extends IProductModelProductDescriptionCulture {
  requestTarget: IProductModelProductDescriptionCulturePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductModelProductDescriptionCulturesService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductModelProductDescriptionCulture, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelProductDescriptionCultureLookupModel>;
  create(model: IProductModelProductDescriptionCulture, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelProductDescriptionCultureLookupModel>>;
  create(model: IProductModelProductDescriptionCulture, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelProductDescriptionCultureLookupModel>>;
  create(model: IProductModelProductDescriptionCulture, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductModelProductDescriptionCulture, IProductModelProductDescriptionCultureLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductModelProductDescriptionCulture>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductModelProductDescriptionCultureLookupModel>>;
  createMany(model: Array<IProductModelProductDescriptionCulture>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductModelProductDescriptionCultureLookupModel>>>;
  createMany(model: Array<IProductModelProductDescriptionCulture>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductModelProductDescriptionCultureLookupModel>>>;
  createMany(model: Array<IProductModelProductDescriptionCulture>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductModelProductDescriptionCulture>, Array<IProductModelProductDescriptionCultureLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures', {
      productModelID,
      productDescriptionID,
      cultureID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductModelProductDescriptionCulturePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductModelProductDescriptionCulturePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductModelProductDescriptionCulturePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductModelProductDescriptionCulturePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductModelProductDescriptionCulturePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productModelID: number, productDescriptionID: number, cultureID: string, model: IProductModelProductDescriptionCultureUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelProductDescriptionCultureLookupModel>;
  update(productModelID: number, productDescriptionID: number, cultureID: string, model: IProductModelProductDescriptionCultureUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelProductDescriptionCultureLookupModel>>;
  update(productModelID: number, productDescriptionID: number, cultureID: string, model: IProductModelProductDescriptionCultureUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelProductDescriptionCultureLookupModel>>;
  update(productModelID: number, productDescriptionID: number, cultureID: string, model: IProductModelProductDescriptionCultureUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures', {
      productModelID,
      productDescriptionID,
      cultureID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductModelProductDescriptionCultureUpdateModel, IProductModelProductDescriptionCultureLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductModelProductDescriptionCultureUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductModelProductDescriptionCultureLookupModel>>;
  updateMany(model: Array<IProductModelProductDescriptionCultureUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductModelProductDescriptionCultureLookupModel>>>;
  updateMany(model: Array<IProductModelProductDescriptionCultureUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductModelProductDescriptionCultureLookupModel>>>;
  updateMany(model: Array<IProductModelProductDescriptionCultureUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductModelProductDescriptionCultureUpdateItem>, Array<IProductModelProductDescriptionCultureLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelProductDescriptionCultureLookupModel>;
  get(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelProductDescriptionCultureLookupModel>>;
  get(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelProductDescriptionCultureLookupModel>>;
  get(productModelID: number, productDescriptionID: number, cultureID: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures', {
      productModelID,
      productDescriptionID,
      cultureID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductModelProductDescriptionCultureLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByCulture(cultureID: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelProductDescriptionCulturesListViewModel>;
  getByCulture(cultureID: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelProductDescriptionCulturesListViewModel>>;
  getByCulture(cultureID: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelProductDescriptionCulturesListViewModel>>;
  getByCulture(cultureID: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures/GetProductModelProductDescriptionCulturesByCulture', {
      cultureID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductModelProductDescriptionCulturesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProductDescription(productDescriptionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelProductDescriptionCulturesListViewModel>;
  getByProductDescription(productDescriptionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelProductDescriptionCulturesListViewModel>>;
  getByProductDescription(productDescriptionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelProductDescriptionCulturesListViewModel>>;
  getByProductDescription(productDescriptionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures/GetProductModelProductDescriptionCulturesByProductDescription', {
      productDescriptionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductModelProductDescriptionCulturesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProductModel(productModelID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelProductDescriptionCulturesListViewModel>;
  getByProductModel(productModelID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelProductDescriptionCulturesListViewModel>>;
  getByProductModel(productModelID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelProductDescriptionCulturesListViewModel>>;
  getByProductModel(productModelID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelProductDescriptionCultures/GetProductModelProductDescriptionCulturesByProductModel', {
      productModelID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductModelProductDescriptionCulturesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
