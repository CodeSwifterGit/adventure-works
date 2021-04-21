import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICustomer } from 'app/models/data/entities/sales/customer/customer';
import { ICustomerLookupModel } from 'app/models/data/entities/sales/customer/customer-lookup-model';
import { ICustomerUpdateModel } from 'app/models/data/entities/sales/customer/customer-update-model';
import { ICustomersListViewModel } from 'app/models/data/entities/sales/customer/customers-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICustomerPrimaryKey {
  customerID: number;
}

export interface ICustomerUpdateItem extends ICustomer {
  requestTarget: ICustomerPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  constructor(protected apiClient: DataService) {}

  create(model: ICustomer, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerLookupModel>;
  create(model: ICustomer, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerLookupModel>>;
  create(model: ICustomer, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerLookupModel>>;
  create(model: ICustomer, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Customers', {});

    return this.apiClient.create<ICustomer, ICustomerLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICustomer>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICustomerLookupModel>>;
  createMany(model: Array<ICustomer>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICustomerLookupModel>>>;
  createMany(model: Array<ICustomer>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICustomerLookupModel>>>;
  createMany(model: Array<ICustomer>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Customers/createMany', {});

    return this.apiClient.create<Array<ICustomer>, Array<ICustomerLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Customers', {
      customerID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICustomerPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICustomerPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICustomerPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICustomerPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Customers/DeleteMany', {});

    return this.apiClient.post<Array<ICustomerPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(customerID: number, model: ICustomerUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerLookupModel>;
  update(customerID: number, model: ICustomerUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerLookupModel>>;
  update(customerID: number, model: ICustomerUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerLookupModel>>;
  update(customerID: number, model: ICustomerUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Customers', {
      customerID,
    });

    return this.apiClient.update<ICustomerUpdateModel, ICustomerLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICustomerUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICustomerLookupModel>>;
  updateMany(model: Array<ICustomerUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICustomerLookupModel>>>;
  updateMany(model: Array<ICustomerUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICustomerLookupModel>>>;
  updateMany(model: Array<ICustomerUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Customers/UpdateMany', {});

    return this.apiClient.update<Array<ICustomerUpdateItem>, Array<ICustomerLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerLookupModel>;
  get(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerLookupModel>>;
  get(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerLookupModel>>;
  get(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Customers', {
      customerID,
    });

    return this.apiClient.get<ICustomerLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomersListViewModel>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomersListViewModel>>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomersListViewModel>>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Customers/GetCustomersBySalesTerritory', {
      territoryID,
    });

    return this.apiClient.get<ICustomersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
