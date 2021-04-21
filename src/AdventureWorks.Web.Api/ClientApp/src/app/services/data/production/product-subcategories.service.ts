import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductSubcategory } from 'app/models/data/entities/production/product-subcategory/product-subcategory';
import { IProductSubcategoryLookupModel } from 'app/models/data/entities/production/product-subcategory/product-subcategory-lookup-model';
import { IProductSubcategoryUpdateModel } from 'app/models/data/entities/production/product-subcategory/product-subcategory-update-model';
import { IProductSubcategoriesListViewModel } from 'app/models/data/entities/production/product-subcategory/product-subcategories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductSubcategoryPrimaryKey {
  productSubcategoryID: number;
}

export interface IProductSubcategoryUpdateItem extends IProductSubcategory {
  requestTarget: IProductSubcategoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductSubcategoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductSubcategory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductSubcategoryLookupModel>;
  create(model: IProductSubcategory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductSubcategoryLookupModel>>;
  create(model: IProductSubcategory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductSubcategoryLookupModel>>;
  create(model: IProductSubcategory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories', {});

    return this.apiClient.create<IProductSubcategory, IProductSubcategoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductSubcategory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductSubcategoryLookupModel>>;
  createMany(model: Array<IProductSubcategory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductSubcategoryLookupModel>>>;
  createMany(model: Array<IProductSubcategory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductSubcategoryLookupModel>>>;
  createMany(model: Array<IProductSubcategory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories/createMany', {});

    return this.apiClient.create<Array<IProductSubcategory>, Array<IProductSubcategoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productSubcategoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productSubcategoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productSubcategoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productSubcategoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories', {
      productSubcategoryID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductSubcategoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductSubcategoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductSubcategoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductSubcategoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories/DeleteMany', {});

    return this.apiClient.post<Array<IProductSubcategoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productSubcategoryID: number, model: IProductSubcategoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductSubcategoryLookupModel>;
  update(productSubcategoryID: number, model: IProductSubcategoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductSubcategoryLookupModel>>;
  update(productSubcategoryID: number, model: IProductSubcategoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductSubcategoryLookupModel>>;
  update(productSubcategoryID: number, model: IProductSubcategoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories', {
      productSubcategoryID,
    });

    return this.apiClient.update<IProductSubcategoryUpdateModel, IProductSubcategoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductSubcategoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductSubcategoryLookupModel>>;
  updateMany(model: Array<IProductSubcategoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductSubcategoryLookupModel>>>;
  updateMany(model: Array<IProductSubcategoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductSubcategoryLookupModel>>>;
  updateMany(model: Array<IProductSubcategoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories/UpdateMany', {});

    return this.apiClient.update<Array<IProductSubcategoryUpdateItem>, Array<IProductSubcategoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productSubcategoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductSubcategoryLookupModel>;
  get(productSubcategoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductSubcategoryLookupModel>>;
  get(productSubcategoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductSubcategoryLookupModel>>;
  get(productSubcategoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories', {
      productSubcategoryID,
    });

    return this.apiClient.get<IProductSubcategoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProductCategory(productCategoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductSubcategoriesListViewModel>;
  getByProductCategory(productCategoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductSubcategoriesListViewModel>>;
  getByProductCategory(productCategoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductSubcategoriesListViewModel>>;
  getByProductCategory(productCategoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductSubcategories/GetProductSubcategoriesByProductCategory', {
      productCategoryID,
    });

    return this.apiClient.get<IProductSubcategoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
