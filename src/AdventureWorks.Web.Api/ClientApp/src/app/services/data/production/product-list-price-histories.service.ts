import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductListPriceHistory } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history';
import { IProductListPriceHistoryLookupModel } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history-lookup-model';
import { IProductListPriceHistoryUpdateModel } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history-update-model';
import { IProductListPriceHistoriesListViewModel } from 'app/models/data/entities/production/product-list-price-history/product-list-price-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductListPriceHistoryPrimaryKey {
  productID: number;
  startDate: Date | string;
}

export interface IProductListPriceHistoryUpdateItem extends IProductListPriceHistory {
  requestTarget: IProductListPriceHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductListPriceHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductListPriceHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductListPriceHistoryLookupModel>;
  create(model: IProductListPriceHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductListPriceHistoryLookupModel>>;
  create(model: IProductListPriceHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductListPriceHistoryLookupModel>>;
  create(model: IProductListPriceHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductListPriceHistory, IProductListPriceHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductListPriceHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductListPriceHistoryLookupModel>>;
  createMany(model: Array<IProductListPriceHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductListPriceHistoryLookupModel>>>;
  createMany(model: Array<IProductListPriceHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductListPriceHistoryLookupModel>>>;
  createMany(model: Array<IProductListPriceHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductListPriceHistory>, Array<IProductListPriceHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories', {
      productID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductListPriceHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductListPriceHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductListPriceHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductListPriceHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductListPriceHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, startDate: Date | string, model: IProductListPriceHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductListPriceHistoryLookupModel>;
  update(productID: number, startDate: Date | string, model: IProductListPriceHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductListPriceHistoryLookupModel>>;
  update(productID: number, startDate: Date | string, model: IProductListPriceHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductListPriceHistoryLookupModel>>;
  update(productID: number, startDate: Date | string, model: IProductListPriceHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories', {
      productID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductListPriceHistoryUpdateModel, IProductListPriceHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductListPriceHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductListPriceHistoryLookupModel>>;
  updateMany(model: Array<IProductListPriceHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductListPriceHistoryLookupModel>>>;
  updateMany(model: Array<IProductListPriceHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductListPriceHistoryLookupModel>>>;
  updateMany(model: Array<IProductListPriceHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductListPriceHistoryUpdateItem>, Array<IProductListPriceHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductListPriceHistoryLookupModel>;
  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductListPriceHistoryLookupModel>>;
  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductListPriceHistoryLookupModel>>;
  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories', {
      productID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductListPriceHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductListPriceHistoriesListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductListPriceHistoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductListPriceHistoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductListPriceHistories/GetProductListPriceHistoriesByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductListPriceHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
