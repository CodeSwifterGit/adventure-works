import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductCategory } from 'app/models/data/entities/production/product-category/product-category';
import { IProductCategoryLookupModel } from 'app/models/data/entities/production/product-category/product-category-lookup-model';
import { IProductCategoryUpdateModel } from 'app/models/data/entities/production/product-category/product-category-update-model';
import { IProductCategoriesListViewModel } from 'app/models/data/entities/production/product-category/product-categories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductCategoryPrimaryKey {
  productCategoryID: number;
}

export interface IProductCategoryUpdateItem extends IProductCategory {
  requestTarget: IProductCategoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductCategoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductCategory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCategoryLookupModel>;
  create(model: IProductCategory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCategoryLookupModel>>;
  create(model: IProductCategory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCategoryLookupModel>>;
  create(model: IProductCategory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductCategory, IProductCategoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductCategory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductCategoryLookupModel>>;
  createMany(model: Array<IProductCategory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductCategoryLookupModel>>>;
  createMany(model: Array<IProductCategory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductCategoryLookupModel>>>;
  createMany(model: Array<IProductCategory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductCategory>, Array<IProductCategoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productCategoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productCategoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productCategoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productCategoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories', {
      productCategoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductCategoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductCategoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductCategoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductCategoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductCategoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productCategoryID: number, model: IProductCategoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCategoryLookupModel>;
  update(productCategoryID: number, model: IProductCategoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCategoryLookupModel>>;
  update(productCategoryID: number, model: IProductCategoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCategoryLookupModel>>;
  update(productCategoryID: number, model: IProductCategoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories', {
      productCategoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductCategoryUpdateModel, IProductCategoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductCategoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductCategoryLookupModel>>;
  updateMany(model: Array<IProductCategoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductCategoryLookupModel>>>;
  updateMany(model: Array<IProductCategoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductCategoryLookupModel>>>;
  updateMany(model: Array<IProductCategoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductCategoryUpdateItem>, Array<IProductCategoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productCategoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCategoryLookupModel>;
  get(productCategoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCategoryLookupModel>>;
  get(productCategoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCategoryLookupModel>>;
  get(productCategoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories', {
      productCategoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductCategoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCategoriesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCategoriesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCategoriesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductCategories/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IProductCategoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
