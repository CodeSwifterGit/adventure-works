import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ITransactionHistoryArchive } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive';
import { ITransactionHistoryArchiveLookupModel } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive-lookup-model';
import { ITransactionHistoryArchiveUpdateModel } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archive-update-model';
import { ITransactionHistoryArchivesListViewModel } from 'app/models/data/entities/production/transaction-history-archive/transaction-history-archives-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ITransactionHistoryArchivePrimaryKey {
  transactionID: number;
}

export interface ITransactionHistoryArchiveUpdateItem extends ITransactionHistoryArchive {
  requestTarget: ITransactionHistoryArchivePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class TransactionHistoryArchivesService {
  constructor(protected apiClient: DataService) {}

  create(model: ITransactionHistoryArchive, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryArchiveLookupModel>;
  create(model: ITransactionHistoryArchive, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryArchiveLookupModel>>;
  create(model: ITransactionHistoryArchive, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryArchiveLookupModel>>;
  create(model: ITransactionHistoryArchive, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ITransactionHistoryArchive, ITransactionHistoryArchiveLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ITransactionHistoryArchive>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ITransactionHistoryArchiveLookupModel>>;
  createMany(model: Array<ITransactionHistoryArchive>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ITransactionHistoryArchiveLookupModel>>>;
  createMany(model: Array<ITransactionHistoryArchive>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ITransactionHistoryArchiveLookupModel>>>;
  createMany(model: Array<ITransactionHistoryArchive>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ITransactionHistoryArchive>, Array<ITransactionHistoryArchiveLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(transactionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(transactionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(transactionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(transactionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives', {
      transactionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ITransactionHistoryArchivePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ITransactionHistoryArchivePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ITransactionHistoryArchivePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ITransactionHistoryArchivePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ITransactionHistoryArchivePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(transactionID: number, model: ITransactionHistoryArchiveUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryArchiveLookupModel>;
  update(transactionID: number, model: ITransactionHistoryArchiveUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryArchiveLookupModel>>;
  update(transactionID: number, model: ITransactionHistoryArchiveUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryArchiveLookupModel>>;
  update(transactionID: number, model: ITransactionHistoryArchiveUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives', {
      transactionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ITransactionHistoryArchiveUpdateModel, ITransactionHistoryArchiveLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ITransactionHistoryArchiveUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ITransactionHistoryArchiveLookupModel>>;
  updateMany(model: Array<ITransactionHistoryArchiveUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ITransactionHistoryArchiveLookupModel>>>;
  updateMany(model: Array<ITransactionHistoryArchiveUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ITransactionHistoryArchiveLookupModel>>>;
  updateMany(model: Array<ITransactionHistoryArchiveUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ITransactionHistoryArchiveUpdateItem>, Array<ITransactionHistoryArchiveLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(transactionID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryArchiveLookupModel>;
  get(transactionID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryArchiveLookupModel>>;
  get(transactionID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryArchiveLookupModel>>;
  get(transactionID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives', {
      transactionID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ITransactionHistoryArchiveLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ITransactionHistoryArchivesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ITransactionHistoryArchivesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ITransactionHistoryArchivesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('TransactionHistoryArchives/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<ITransactionHistoryArchivesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
