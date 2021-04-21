import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IDatabaseLog } from 'app/models/data/entities/dbo/database-log/database-log';
import { IDatabaseLogLookupModel } from 'app/models/data/entities/dbo/database-log/database-log-lookup-model';
import { IDatabaseLogUpdateModel } from 'app/models/data/entities/dbo/database-log/database-log-update-model';
import { IDatabaseLogsListViewModel } from 'app/models/data/entities/dbo/database-log/database-logs-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IDatabaseLogPrimaryKey {
  databaseLogID: number;
}

export interface IDatabaseLogUpdateItem extends IDatabaseLog {
  requestTarget: IDatabaseLogPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class DatabaseLogsService {
  constructor(protected apiClient: DataService) {}

  create(model: IDatabaseLog, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDatabaseLogLookupModel>;
  create(model: IDatabaseLog, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDatabaseLogLookupModel>>;
  create(model: IDatabaseLog, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDatabaseLogLookupModel>>;
  create(model: IDatabaseLog, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs', {});

    return this.apiClient.create<IDatabaseLog, IDatabaseLogLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IDatabaseLog>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IDatabaseLogLookupModel>>;
  createMany(model: Array<IDatabaseLog>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IDatabaseLogLookupModel>>>;
  createMany(model: Array<IDatabaseLog>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IDatabaseLogLookupModel>>>;
  createMany(model: Array<IDatabaseLog>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs/createMany', {});

    return this.apiClient.create<Array<IDatabaseLog>, Array<IDatabaseLogLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(databaseLogID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(databaseLogID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(databaseLogID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(databaseLogID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs', {
      databaseLogID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IDatabaseLogPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IDatabaseLogPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IDatabaseLogPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IDatabaseLogPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs/DeleteMany', {});

    return this.apiClient.post<Array<IDatabaseLogPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(databaseLogID: number, model: IDatabaseLogUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDatabaseLogLookupModel>;
  update(databaseLogID: number, model: IDatabaseLogUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDatabaseLogLookupModel>>;
  update(databaseLogID: number, model: IDatabaseLogUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDatabaseLogLookupModel>>;
  update(databaseLogID: number, model: IDatabaseLogUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs', {
      databaseLogID,
    });

    return this.apiClient.update<IDatabaseLogUpdateModel, IDatabaseLogLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IDatabaseLogUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IDatabaseLogLookupModel>>;
  updateMany(model: Array<IDatabaseLogUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IDatabaseLogLookupModel>>>;
  updateMany(model: Array<IDatabaseLogUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IDatabaseLogLookupModel>>>;
  updateMany(model: Array<IDatabaseLogUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs/UpdateMany', {});

    return this.apiClient.update<Array<IDatabaseLogUpdateItem>, Array<IDatabaseLogLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(databaseLogID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDatabaseLogLookupModel>;
  get(databaseLogID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDatabaseLogLookupModel>>;
  get(databaseLogID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDatabaseLogLookupModel>>;
  get(databaseLogID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs', {
      databaseLogID,
    });

    return this.apiClient.get<IDatabaseLogLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDatabaseLogsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDatabaseLogsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDatabaseLogsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('DatabaseLogs/all', {});

    return this.apiClient.get<IDatabaseLogsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
