import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductCostHistory } from 'app/models/data/entities/production/product-cost-history/product-cost-history';
import { IProductCostHistoryLookupModel } from 'app/models/data/entities/production/product-cost-history/product-cost-history-lookup-model';
import { IProductCostHistoryUpdateModel } from 'app/models/data/entities/production/product-cost-history/product-cost-history-update-model';
import { IProductCostHistoriesListViewModel } from 'app/models/data/entities/production/product-cost-history/product-cost-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductCostHistoryPrimaryKey {
  productID: number;
  startDate: Date | string;
}

export interface IProductCostHistoryUpdateItem extends IProductCostHistory {
  requestTarget: IProductCostHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductCostHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductCostHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCostHistoryLookupModel>;
  create(model: IProductCostHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCostHistoryLookupModel>>;
  create(model: IProductCostHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCostHistoryLookupModel>>;
  create(model: IProductCostHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductCostHistory, IProductCostHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductCostHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductCostHistoryLookupModel>>;
  createMany(model: Array<IProductCostHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductCostHistoryLookupModel>>>;
  createMany(model: Array<IProductCostHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductCostHistoryLookupModel>>>;
  createMany(model: Array<IProductCostHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductCostHistory>, Array<IProductCostHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories', {
      productID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductCostHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductCostHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductCostHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductCostHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductCostHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, startDate: Date | string, model: IProductCostHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCostHistoryLookupModel>;
  update(productID: number, startDate: Date | string, model: IProductCostHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCostHistoryLookupModel>>;
  update(productID: number, startDate: Date | string, model: IProductCostHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCostHistoryLookupModel>>;
  update(productID: number, startDate: Date | string, model: IProductCostHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories', {
      productID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductCostHistoryUpdateModel, IProductCostHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductCostHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductCostHistoryLookupModel>>;
  updateMany(model: Array<IProductCostHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductCostHistoryLookupModel>>>;
  updateMany(model: Array<IProductCostHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductCostHistoryLookupModel>>>;
  updateMany(model: Array<IProductCostHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductCostHistoryUpdateItem>, Array<IProductCostHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCostHistoryLookupModel>;
  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCostHistoryLookupModel>>;
  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCostHistoryLookupModel>>;
  get(productID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories', {
      productID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductCostHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductCostHistoriesListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductCostHistoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductCostHistoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductCostHistories/GetProductCostHistoriesByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductCostHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
