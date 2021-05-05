import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProduct } from 'app/models/data/entities/production/product/product';
import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';
import { IProductsListViewModel } from 'app/models/data/entities/production/product/products-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductPrimaryKey {
  productID: number;
}

export interface IProductUpdateItem extends IProduct {
  requestTarget: IProductPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  constructor(protected apiClient: DataService) {}

  create(model: IProduct, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductLookupModel>;
  create(model: IProduct, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductLookupModel>>;
  create(model: IProduct, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductLookupModel>>;
  create(model: IProduct, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Products', {});

    return this.apiClient.create<IProduct, IProductLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProduct>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductLookupModel>>;
  createMany(model: Array<IProduct>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductLookupModel>>>;
  createMany(model: Array<IProduct>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductLookupModel>>>;
  createMany(model: Array<IProduct>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Products/createMany', {});

    return this.apiClient.create<Array<IProduct>, Array<IProductLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Products', {
      productID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Products/DeleteMany', {});

    return this.apiClient.post<Array<IProductPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, model: IProductUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductLookupModel>;
  update(productID: number, model: IProductUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductLookupModel>>;
  update(productID: number, model: IProductUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductLookupModel>>;
  update(productID: number, model: IProductUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Products', {
      productID,
    });

    return this.apiClient.update<IProductUpdateModel, IProductLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductLookupModel>>;
  updateMany(model: Array<IProductUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductLookupModel>>>;
  updateMany(model: Array<IProductUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductLookupModel>>>;
  updateMany(model: Array<IProductUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Products/UpdateMany', {});

    return this.apiClient.update<Array<IProductUpdateItem>, Array<IProductLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductLookupModel>;
  get(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductLookupModel>>;
  get(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductLookupModel>>;
  get(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Products', {
      productID,
    });

    return this.apiClient.get<IProductLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProductModel(productModelID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductsListViewModel>;
  getByProductModel(productModelID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductsListViewModel>>;
  getByProductModel(productModelID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductsListViewModel>>;
  getByProductModel(productModelID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Products/GetProductsByProductModel', {
      productModelID,
    });

    return this.apiClient.get<IProductsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProductSubcategory(productSubcategoryID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductsListViewModel>;
  getByProductSubcategory(productSubcategoryID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductsListViewModel>>;
  getByProductSubcategory(productSubcategoryID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductsListViewModel>>;
  getByProductSubcategory(productSubcategoryID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Products/GetProductsByProductSubcategory', {
      productSubcategoryID,
    });

    return this.apiClient.get<IProductsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByUnitMeasureSize(sizeUnitMeasureCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductsListViewModel>;
  getByUnitMeasureSize(sizeUnitMeasureCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductsListViewModel>>;
  getByUnitMeasureSize(sizeUnitMeasureCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductsListViewModel>>;
  getByUnitMeasureSize(sizeUnitMeasureCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Products/GetProductsByUnitMeasureSize', {
      sizeUnitMeasureCode,
    });

    return this.apiClient.get<IProductsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByUnitMeasureWeight(weightUnitMeasureCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductsListViewModel>;
  getByUnitMeasureWeight(weightUnitMeasureCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductsListViewModel>>;
  getByUnitMeasureWeight(weightUnitMeasureCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductsListViewModel>>;
  getByUnitMeasureWeight(weightUnitMeasureCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Products/GetProductsByUnitMeasureWeight', {
      weightUnitMeasureCode,
    });

    return this.apiClient.get<IProductsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
