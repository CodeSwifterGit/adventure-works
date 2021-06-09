import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IDepartment } from 'app/models/data/entities/human-resources/department/department';
import { IDepartmentLookupModel } from 'app/models/data/entities/human-resources/department/department-lookup-model';
import { IDepartmentUpdateModel } from 'app/models/data/entities/human-resources/department/department-update-model';
import { IDepartmentsListViewModel } from 'app/models/data/entities/human-resources/department/departments-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IDepartmentPrimaryKey {
  departmentID: number;
}

export interface IDepartmentUpdateItem extends IDepartment {
  requestTarget: IDepartmentPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class DepartmentsService {
  constructor(protected apiClient: DataService) { }

  create(model: IDepartment, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDepartmentLookupModel>;
  create(model: IDepartment, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDepartmentLookupModel>>;
  create(model: IDepartment, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDepartmentLookupModel>>;
  create(model: IDepartment, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Departments', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IDepartment, IDepartmentLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IDepartment>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IDepartmentLookupModel>>;
  createMany(model: Array<IDepartment>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IDepartmentLookupModel>>>;
  createMany(model: Array<IDepartment>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IDepartmentLookupModel>>>;
  createMany(model: Array<IDepartment>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Departments/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IDepartment>, Array<IDepartmentLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(departmentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(departmentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(departmentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(departmentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Departments', {
      departmentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IDepartmentPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IDepartmentPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IDepartmentPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IDepartmentPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Departments/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IDepartmentPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(departmentID: number, model: IDepartmentUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDepartmentLookupModel>;
  update(departmentID: number, model: IDepartmentUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDepartmentLookupModel>>;
  update(departmentID: number, model: IDepartmentUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDepartmentLookupModel>>;
  update(departmentID: number, model: IDepartmentUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Departments', {
      departmentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IDepartmentUpdateModel, IDepartmentLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IDepartmentUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IDepartmentLookupModel>>;
  updateMany(model: Array<IDepartmentUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IDepartmentLookupModel>>>;
  updateMany(model: Array<IDepartmentUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IDepartmentLookupModel>>>;
  updateMany(model: Array<IDepartmentUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Departments/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IDepartmentUpdateItem>, Array<IDepartmentLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(departmentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDepartmentLookupModel>;
  get(departmentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDepartmentLookupModel>>;
  get(departmentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDepartmentLookupModel>>;
  get(departmentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Departments', {
      departmentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IDepartmentLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDepartmentsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDepartmentsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDepartmentsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Departments/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IDepartmentsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
