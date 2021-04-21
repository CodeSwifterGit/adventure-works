import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IEmployeeDepartmentHistory } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history';
import { IEmployeeDepartmentHistoryLookupModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-lookup-model';
import { IEmployeeDepartmentHistoryUpdateModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-history-update-model';
import { IEmployeeDepartmentHistoriesListViewModel } from 'app/models/data/entities/human-resources/employee-department-history/employee-department-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IEmployeeDepartmentHistoryPrimaryKey {
  employeeID: number;
  departmentID: number;
  shiftID: number;
  startDate: Date | string;
}

export interface IEmployeeDepartmentHistoryUpdateItem extends IEmployeeDepartmentHistory {
  requestTarget: IEmployeeDepartmentHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class EmployeeDepartmentHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IEmployeeDepartmentHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeDepartmentHistoryLookupModel>;
  create(model: IEmployeeDepartmentHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeDepartmentHistoryLookupModel>>;
  create(model: IEmployeeDepartmentHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeDepartmentHistoryLookupModel>>;
  create(model: IEmployeeDepartmentHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories', {});

    return this.apiClient.create<IEmployeeDepartmentHistory, IEmployeeDepartmentHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IEmployeeDepartmentHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeeDepartmentHistoryLookupModel>>;
  createMany(model: Array<IEmployeeDepartmentHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeeDepartmentHistoryLookupModel>>>;
  createMany(model: Array<IEmployeeDepartmentHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeeDepartmentHistoryLookupModel>>>;
  createMany(model: Array<IEmployeeDepartmentHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories/createMany', {});

    return this.apiClient.create<Array<IEmployeeDepartmentHistory>, Array<IEmployeeDepartmentHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories', {
      employeeID,
      departmentID,
      shiftID,
      startDate,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IEmployeeDepartmentHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IEmployeeDepartmentHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IEmployeeDepartmentHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IEmployeeDepartmentHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories/DeleteMany', {});

    return this.apiClient.post<Array<IEmployeeDepartmentHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, model: IEmployeeDepartmentHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeDepartmentHistoryLookupModel>;
  update(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, model: IEmployeeDepartmentHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeDepartmentHistoryLookupModel>>;
  update(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, model: IEmployeeDepartmentHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeDepartmentHistoryLookupModel>>;
  update(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, model: IEmployeeDepartmentHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories', {
      employeeID,
      departmentID,
      shiftID,
      startDate,
    });

    return this.apiClient.update<IEmployeeDepartmentHistoryUpdateModel, IEmployeeDepartmentHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IEmployeeDepartmentHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeeDepartmentHistoryLookupModel>>;
  updateMany(model: Array<IEmployeeDepartmentHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeeDepartmentHistoryLookupModel>>>;
  updateMany(model: Array<IEmployeeDepartmentHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeeDepartmentHistoryLookupModel>>>;
  updateMany(model: Array<IEmployeeDepartmentHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories/UpdateMany', {});

    return this.apiClient.update<Array<IEmployeeDepartmentHistoryUpdateItem>, Array<IEmployeeDepartmentHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeDepartmentHistoryLookupModel>;
  get(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeDepartmentHistoryLookupModel>>;
  get(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeDepartmentHistoryLookupModel>>;
  get(employeeID: number, departmentID: number, shiftID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories', {
      employeeID,
      departmentID,
      shiftID,
      startDate,
    });

    return this.apiClient.get<IEmployeeDepartmentHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByDepartment(departmentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeDepartmentHistoriesListViewModel>;
  getByDepartment(departmentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeDepartmentHistoriesListViewModel>>;
  getByDepartment(departmentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeDepartmentHistoriesListViewModel>>;
  getByDepartment(departmentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories/GetEmployeeDepartmentHistoriesByDepartment', {
      departmentID,
    });

    return this.apiClient.get<IEmployeeDepartmentHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeDepartmentHistoriesListViewModel>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeDepartmentHistoriesListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeDepartmentHistoriesListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories/GetEmployeeDepartmentHistoriesByEmployee', {
      employeeID,
    });

    return this.apiClient.get<IEmployeeDepartmentHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByShift(shiftID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeDepartmentHistoriesListViewModel>;
  getByShift(shiftID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeDepartmentHistoriesListViewModel>>;
  getByShift(shiftID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeDepartmentHistoriesListViewModel>>;
  getByShift(shiftID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeDepartmentHistories/GetEmployeeDepartmentHistoriesByShift', {
      shiftID,
    });

    return this.apiClient.get<IEmployeeDepartmentHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
