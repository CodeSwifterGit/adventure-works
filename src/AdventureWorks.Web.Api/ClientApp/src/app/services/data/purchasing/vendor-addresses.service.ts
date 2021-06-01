import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IVendorAddress } from 'app/models/data/entities/purchasing/vendor-address/vendor-address';
import { IVendorAddressLookupModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-lookup-model';
import { IVendorAddressUpdateModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-update-model';
import { IVendorAddressesListViewModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-addresses-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IVendorAddressPrimaryKey {
  vendorID: number;
  addressID: number;
}

export interface IVendorAddressUpdateItem extends IVendorAddress {
  requestTarget: IVendorAddressPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class VendorAddressesService {
  constructor(protected apiClient: DataService) {}

  create(model: IVendorAddress, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorAddressLookupModel>;
  create(model: IVendorAddress, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorAddressLookupModel>>;
  create(model: IVendorAddress, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorAddressLookupModel>>;
  create(model: IVendorAddress, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IVendorAddress, IVendorAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IVendorAddress>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IVendorAddressLookupModel>>;
  createMany(model: Array<IVendorAddress>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IVendorAddressLookupModel>>>;
  createMany(model: Array<IVendorAddress>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IVendorAddressLookupModel>>>;
  createMany(model: Array<IVendorAddress>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IVendorAddress>, Array<IVendorAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(vendorID: number, addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(vendorID: number, addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(vendorID: number, addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(vendorID: number, addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses', {
      vendorID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IVendorAddressPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IVendorAddressPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IVendorAddressPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IVendorAddressPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IVendorAddressPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(vendorID: number, addressID: number, model: IVendorAddressUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorAddressLookupModel>;
  update(vendorID: number, addressID: number, model: IVendorAddressUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorAddressLookupModel>>;
  update(vendorID: number, addressID: number, model: IVendorAddressUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorAddressLookupModel>>;
  update(vendorID: number, addressID: number, model: IVendorAddressUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses', {
      vendorID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IVendorAddressUpdateModel, IVendorAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IVendorAddressUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IVendorAddressLookupModel>>;
  updateMany(model: Array<IVendorAddressUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IVendorAddressLookupModel>>>;
  updateMany(model: Array<IVendorAddressUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IVendorAddressLookupModel>>>;
  updateMany(model: Array<IVendorAddressUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IVendorAddressUpdateItem>, Array<IVendorAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(vendorID: number, addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorAddressLookupModel>;
  get(vendorID: number, addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorAddressLookupModel>>;
  get(vendorID: number, addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorAddressLookupModel>>;
  get(vendorID: number, addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses', {
      vendorID,
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorAddressLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorAddressesListViewModel>;
  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorAddressesListViewModel>>;
  getByAddress(addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorAddressesListViewModel>>;
  getByAddress(addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses/GetVendorAddressesByAddress', {
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorAddressesListViewModel>;
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorAddressesListViewModel>>;
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorAddressesListViewModel>>;
  getByAddressType(addressTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses/GetVendorAddressesByAddressType', {
      addressTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorAddressesListViewModel>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorAddressesListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorAddressesListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorAddresses/GetVendorAddressesByVendor', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
