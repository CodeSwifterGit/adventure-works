import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ITransactionHistory } from 'app/models/data/entities/production/transaction-history/transaction-history';
import { ITransactionHistoryLookupModel } from 'app/models/data/entities/production/transaction-history/transaction-history-lookup-model';
import { ITransactionHistoryUpdateModel } from 'app/models/data/entities/production/transaction-history/transaction-history-update-model';
import { ITransactionHistoriesListViewModel } from 'app/models/data/entities/production/transaction-history/transaction-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ITransactionHistoryPrimaryKey {
  transactionID: number;
}

export interface ITransactionHistoryUpdateItem extends ITransactionHistory {
  requestTarget: ITransactionHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class TransactionHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: ITransactionHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryLookupModel>;
  create(model: ITransactionHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryLookupModel>>;
  create(model: ITransactionHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryLookupModel>>;
  create(model: ITransactionHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ITransactionHistory, ITransactionHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ITransactionHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ITransactionHistoryLookupModel>>;
  createMany(model: Array<ITransactionHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ITransactionHistoryLookupModel>>>;
  createMany(model: Array<ITransactionHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ITransactionHistoryLookupModel>>>;
  createMany(model: Array<ITransactionHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ITransactionHistory>, Array<ITransactionHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(transactionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(transactionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(transactionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(transactionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories', {
      transactionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ITransactionHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ITransactionHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ITransactionHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ITransactionHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ITransactionHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(transactionID: number, model: ITransactionHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryLookupModel>;
  update(transactionID: number, model: ITransactionHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryLookupModel>>;
  update(transactionID: number, model: ITransactionHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryLookupModel>>;
  update(transactionID: number, model: ITransactionHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories', {
      transactionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ITransactionHistoryUpdateModel, ITransactionHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ITransactionHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ITransactionHistoryLookupModel>>;
  updateMany(model: Array<ITransactionHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ITransactionHistoryLookupModel>>>;
  updateMany(model: Array<ITransactionHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ITransactionHistoryLookupModel>>>;
  updateMany(model: Array<ITransactionHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ITransactionHistoryUpdateItem>, Array<ITransactionHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(transactionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryLookupModel>;
  get(transactionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryLookupModel>>;
  get(transactionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryLookupModel>>;
  get(transactionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories', {
      transactionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ITransactionHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoriesListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistories/GetTransactionHistoriesByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ITransactionHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
