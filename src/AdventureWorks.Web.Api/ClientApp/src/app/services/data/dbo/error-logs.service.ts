import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IErrorLog } from 'app/models/data/entities/dbo/error-log/error-log';
import { IErrorLogLookupModel } from 'app/models/data/entities/dbo/error-log/error-log-lookup-model';
import { IErrorLogUpdateModel } from 'app/models/data/entities/dbo/error-log/error-log-update-model';
import { IErrorLogsListViewModel } from 'app/models/data/entities/dbo/error-log/error-logs-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IErrorLogPrimaryKey {
  errorLogID: number;
}

export interface IErrorLogUpdateItem extends IErrorLog {
  requestTarget: IErrorLogPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ErrorLogsService {
  constructor(protected apiClient: DataService) { }

  create(model: IErrorLog, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IErrorLogLookupModel>;
  create(model: IErrorLog, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IErrorLogLookupModel>>;
  create(model: IErrorLog, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IErrorLogLookupModel>>;
  create(model: IErrorLog, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IErrorLog, IErrorLogLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IErrorLog>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IErrorLogLookupModel>>;
  createMany(model: Array<IErrorLog>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IErrorLogLookupModel>>>;
  createMany(model: Array<IErrorLog>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IErrorLogLookupModel>>>;
  createMany(model: Array<IErrorLog>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IErrorLog>, Array<IErrorLogLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(errorLogID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(errorLogID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(errorLogID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(errorLogID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs', {
      errorLogID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IErrorLogPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IErrorLogPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IErrorLogPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IErrorLogPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IErrorLogPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(errorLogID: number, model: IErrorLogUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IErrorLogLookupModel>;
  update(errorLogID: number, model: IErrorLogUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IErrorLogLookupModel>>;
  update(errorLogID: number, model: IErrorLogUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IErrorLogLookupModel>>;
  update(errorLogID: number, model: IErrorLogUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs', {
      errorLogID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IErrorLogUpdateModel, IErrorLogLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IErrorLogUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IErrorLogLookupModel>>;
  updateMany(model: Array<IErrorLogUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IErrorLogLookupModel>>>;
  updateMany(model: Array<IErrorLogUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IErrorLogLookupModel>>>;
  updateMany(model: Array<IErrorLogUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IErrorLogUpdateItem>, Array<IErrorLogLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(errorLogID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IErrorLogLookupModel>;
  get(errorLogID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IErrorLogLookupModel>>;
  get(errorLogID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IErrorLogLookupModel>>;
  get(errorLogID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs', {
      errorLogID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IErrorLogLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IErrorLogsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IErrorLogsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IErrorLogsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ErrorLogs/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IErrorLogsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
