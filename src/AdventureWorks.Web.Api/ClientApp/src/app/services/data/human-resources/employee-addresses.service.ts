import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IEmployeeAddress } from 'app/models/data/entities/human-resources/employee-address/employee-address';
import { IEmployeeAddressLookupModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-lookup-model';
import { IEmployeeAddressUpdateModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-update-model';
import { IEmployeeAddressesListViewModel } from 'app/models/data/entities/human-resources/employee-address/employee-addresses-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IEmployeeAddressPrimaryKey {
  employeeID: number;
  addressID: number;
}

export interface IEmployeeAddressUpdateItem extends IEmployeeAddress {
  requestTarget: IEmployeeAddressPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class EmployeeAddressesService {
  constructor(protected apiClient: DataService) { }

  create(model: IEmployeeAddress, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeAddressLookupModel>;
  create(model: IEmployeeAddress, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeAddressLookupModel>>;
  create(model: IEmployeeAddress, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeAddressLookupModel>>;
  create(model: IEmployeeAddress, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IEmployeeAddress, IEmployeeAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IEmployeeAddress>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeeAddressLookupModel>>;
  createMany(model: Array<IEmployeeAddress>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeeAddressLookupModel>>>;
  createMany(model: Array<IEmployeeAddress>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeeAddressLookupModel>>>;
  createMany(model: Array<IEmployeeAddress>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IEmployeeAddress>, Array<IEmployeeAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(employeeID: number, addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(employeeID: number, addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(employeeID: number, addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(employeeID: number, addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses', {
      employeeID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IEmployeeAddressPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IEmployeeAddressPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IEmployeeAddressPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IEmployeeAddressPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IEmployeeAddressPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(employeeID: number, addressID: number, model: IEmployeeAddressUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeAddressLookupModel>;
  update(employeeID: number, addressID: number, model: IEmployeeAddressUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeAddressLookupModel>>;
  update(employeeID: number, addressID: number, model: IEmployeeAddressUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeAddressLookupModel>>;
  update(employeeID: number, addressID: number, model: IEmployeeAddressUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses', {
      employeeID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IEmployeeAddressUpdateModel, IEmployeeAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IEmployeeAddressUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IEmployeeAddressLookupModel>>;
  updateMany(model: Array<IEmployeeAddressUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IEmployeeAddressLookupModel>>>;
  updateMany(model: Array<IEmployeeAddressUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IEmployeeAddressLookupModel>>>;
  updateMany(model: Array<IEmployeeAddressUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IEmployeeAddressUpdateItem>, Array<IEmployeeAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(employeeID: number, addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeAddressLookupModel>;
  get(employeeID: number, addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeAddressLookupModel>>;
  get(employeeID: number, addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeAddressLookupModel>>;
  get(employeeID: number, addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses', {
      employeeID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IEmployeeAddressLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeAddressesListViewModel>;
  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeAddressesListViewModel>>;
  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeAddressesListViewModel>>;
  getByAddress(addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses/GetEmployeeAddressesByAddress', {
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IEmployeeAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IEmployeeAddressesListViewModel>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IEmployeeAddressesListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IEmployeeAddressesListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('EmployeeAddresses/GetEmployeeAddressesByEmployee', {
      employeeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IEmployeeAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
