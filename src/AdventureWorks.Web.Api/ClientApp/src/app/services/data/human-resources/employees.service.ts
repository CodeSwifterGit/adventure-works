import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IEmployee } from 'app/models/data/entities/human-resources/employee/employee';
import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';
import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';
import { IEmployeesListViewModel } from 'app/models/data/entities/human-resources/employee/employees-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IEmployeePrimaryKey {
  employeeID: number;
}

export interface IEmployeeUpdateItem extends IEmployee {
  requestTarget: IEmployeePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  constructor(protected apiClient: DataService) {}

  create(model: IEmployee, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeLookupModel>;
  create(model: IEmployee, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeLookupModel>>;
  create(model: IEmployee, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeLookupModel>>;
  create(model: IEmployee, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Employees', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IEmployee, IEmployeeLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IEmployee>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeeLookupModel>>;
  createMany(model: Array<IEmployee>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeeLookupModel>>>;
  createMany(model: Array<IEmployee>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeeLookupModel>>>;
  createMany(model: Array<IEmployee>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Employees/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IEmployee>, Array<IEmployeeLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(employeeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(employeeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(employeeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(employeeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Employees', {
      employeeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IEmployeePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IEmployeePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IEmployeePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IEmployeePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Employees/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IEmployeePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(employeeID: number, model: IEmployeeUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeLookupModel>;
  update(employeeID: number, model: IEmployeeUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeLookupModel>>;
  update(employeeID: number, model: IEmployeeUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeLookupModel>>;
  update(employeeID: number, model: IEmployeeUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Employees', {
      employeeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IEmployeeUpdateModel, IEmployeeLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IEmployeeUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeeLookupModel>>;
  updateMany(model: Array<IEmployeeUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeeLookupModel>>>;
  updateMany(model: Array<IEmployeeUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeeLookupModel>>>;
  updateMany(model: Array<IEmployeeUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Employees/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IEmployeeUpdateItem>, Array<IEmployeeLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(employeeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeLookupModel>;
  get(employeeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeLookupModel>>;
  get(employeeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeLookupModel>>;
  get(employeeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Employees', {
      employeeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IEmployeeLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByContact(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeesListViewModel>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeesListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeesListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Employees/GetEmployeesByContact', {
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IEmployeesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByManager(managerID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeesListViewModel>;
  getByManager(managerID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeesListViewModel>>;
  getByManager(managerID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeesListViewModel>>;
  getByManager(managerID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Employees/GetEmployeesByManager', {
      managerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IEmployeesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
