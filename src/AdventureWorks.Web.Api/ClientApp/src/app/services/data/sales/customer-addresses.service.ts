import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICustomerAddress } from 'app/models/data/entities/sales/customer-address/customer-address';
import { ICustomerAddressLookupModel } from 'app/models/data/entities/sales/customer-address/customer-address-lookup-model';
import { ICustomerAddressUpdateModel } from 'app/models/data/entities/sales/customer-address/customer-address-update-model';
import { ICustomerAddressesListViewModel } from 'app/models/data/entities/sales/customer-address/customer-addresses-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICustomerAddressPrimaryKey {
  customerID: number;
  addressID: number;
}

export interface ICustomerAddressUpdateItem extends ICustomerAddress {
  requestTarget: ICustomerAddressPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CustomerAddressesService {
  constructor(protected apiClient: DataService) {}

  create(model: ICustomerAddress, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerAddressLookupModel>;
  create(model: ICustomerAddress, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerAddressLookupModel>>;
  create(model: ICustomerAddress, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerAddressLookupModel>>;
  create(model: ICustomerAddress, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ICustomerAddress, ICustomerAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICustomerAddress>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICustomerAddressLookupModel>>;
  createMany(model: Array<ICustomerAddress>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICustomerAddressLookupModel>>>;
  createMany(model: Array<ICustomerAddress>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICustomerAddressLookupModel>>>;
  createMany(model: Array<ICustomerAddress>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ICustomerAddress>, Array<ICustomerAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(customerID: number, addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(customerID: number, addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(customerID: number, addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(customerID: number, addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses', {
      customerID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICustomerAddressPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICustomerAddressPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICustomerAddressPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICustomerAddressPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ICustomerAddressPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(customerID: number, addressID: number, model: ICustomerAddressUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerAddressLookupModel>;
  update(customerID: number, addressID: number, model: ICustomerAddressUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerAddressLookupModel>>;
  update(customerID: number, addressID: number, model: ICustomerAddressUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerAddressLookupModel>>;
  update(customerID: number, addressID: number, model: ICustomerAddressUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses', {
      customerID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ICustomerAddressUpdateModel, ICustomerAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICustomerAddressUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICustomerAddressLookupModel>>;
  updateMany(model: Array<ICustomerAddressUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICustomerAddressLookupModel>>>;
  updateMany(model: Array<ICustomerAddressUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICustomerAddressLookupModel>>>;
  updateMany(model: Array<ICustomerAddressUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ICustomerAddressUpdateItem>, Array<ICustomerAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(customerID: number, addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerAddressLookupModel>;
  get(customerID: number, addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerAddressLookupModel>>;
  get(customerID: number, addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerAddressLookupModel>>;
  get(customerID: number, addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses', {
      customerID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICustomerAddressLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerAddressesListViewModel>;
  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerAddressesListViewModel>>;
  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerAddressesListViewModel>>;
  getByAddress(addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses/GetCustomerAddressesByAddress', {
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICustomerAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerAddressesListViewModel>;
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerAddressesListViewModel>>;
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerAddressesListViewModel>>;
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses/GetCustomerAddressesByAddressType', {
      addressTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICustomerAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICustomerAddressesListViewModel>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICustomerAddressesListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICustomerAddressesListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CustomerAddresses/GetCustomerAddressesByCustomer', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICustomerAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
