import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IEmployeePayHistory } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history';
import { IEmployeePayHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history-lookup-model';
import { IEmployeePayHistoryUpdateModel } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-history-update-model';
import { IEmployeePayHistoriesListViewModel } from 'app/models/data/entities/human-resources/employee-pay-history/employee-pay-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IEmployeePayHistoryPrimaryKey {
  employeeID: number;
  rateChangeDate: Date | string;
}

export interface IEmployeePayHistoryUpdateItem extends IEmployeePayHistory {
  requestTarget: IEmployeePayHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class EmployeePayHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IEmployeePayHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeePayHistoryLookupModel>;
  create(model: IEmployeePayHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeePayHistoryLookupModel>>;
  create(model: IEmployeePayHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeePayHistoryLookupModel>>;
  create(model: IEmployeePayHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories', {});

    return this.apiClient.create<IEmployeePayHistory, IEmployeePayHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IEmployeePayHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeePayHistoryLookupModel>>;
  createMany(model: Array<IEmployeePayHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeePayHistoryLookupModel>>>;
  createMany(model: Array<IEmployeePayHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeePayHistoryLookupModel>>>;
  createMany(model: Array<IEmployeePayHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories/createMany', {});

    return this.apiClient.create<Array<IEmployeePayHistory>, Array<IEmployeePayHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories', {
      employeeID,
      rateChangeDate,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IEmployeePayHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IEmployeePayHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IEmployeePayHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IEmployeePayHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories/DeleteMany', {});

    return this.apiClient.post<Array<IEmployeePayHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(employeeID: number, rateChangeDate: Date | string, model: IEmployeePayHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeePayHistoryLookupModel>;
  update(employeeID: number, rateChangeDate: Date | string, model: IEmployeePayHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeePayHistoryLookupModel>>;
  update(employeeID: number, rateChangeDate: Date | string, model: IEmployeePayHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeePayHistoryLookupModel>>;
  update(employeeID: number, rateChangeDate: Date | string, model: IEmployeePayHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories', {
      employeeID,
      rateChangeDate,
    });

    return this.apiClient.update<IEmployeePayHistoryUpdateModel, IEmployeePayHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IEmployeePayHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeePayHistoryLookupModel>>;
  updateMany(model: Array<IEmployeePayHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeePayHistoryLookupModel>>>;
  updateMany(model: Array<IEmployeePayHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeePayHistoryLookupModel>>>;
  updateMany(model: Array<IEmployeePayHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories/UpdateMany', {});

    return this.apiClient.update<Array<IEmployeePayHistoryUpdateItem>, Array<IEmployeePayHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeePayHistoryLookupModel>;
  get(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeePayHistoryLookupModel>>;
  get(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeePayHistoryLookupModel>>;
  get(employeeID: number, rateChangeDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories', {
      employeeID,
      rateChangeDate,
    });

    return this.apiClient.get<IEmployeePayHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeePayHistoriesListViewModel>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeePayHistoriesListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeePayHistoriesListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeePayHistories/GetEmployeePayHistoriesByEmployee', {
      employeeID,
    });

    return this.apiClient.get<IEmployeePayHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
