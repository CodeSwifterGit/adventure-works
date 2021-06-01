import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IAddressType } from 'app/models/data/entities/person/address-type/address-type';
import { IAddressTypeLookupModel } from 'app/models/data/entities/person/address-type/address-type-lookup-model';
import { IAddressTypeUpdateModel } from 'app/models/data/entities/person/address-type/address-type-update-model';
import { IAddressTypesListViewModel } from 'app/models/data/entities/person/address-type/address-types-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IAddressTypePrimaryKey {
  addressTypeID: number;
}

export interface IAddressTypeUpdateItem extends IAddressType {
  requestTarget: IAddressTypePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class AddressTypesService {
  constructor(protected apiClient: DataService) {}

  create(model: IAddressType, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressTypeLookupModel>;
  create(model: IAddressType, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressTypeLookupModel>>;
  create(model: IAddressType, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressTypeLookupModel>>;
  create(model: IAddressType, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IAddressType, IAddressTypeLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IAddressType>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IAddressTypeLookupModel>>;
  createMany(model: Array<IAddressType>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IAddressTypeLookupModel>>>;
  createMany(model: Array<IAddressType>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IAddressTypeLookupModel>>>;
  createMany(model: Array<IAddressType>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IAddressType>, Array<IAddressTypeLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(addressTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(addressTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(addressTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(addressTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes', {
      addressTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IAddressTypePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IAddressTypePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IAddressTypePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IAddressTypePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IAddressTypePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(addressTypeID: number, model: IAddressTypeUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressTypeLookupModel>;
  update(addressTypeID: number, model: IAddressTypeUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressTypeLookupModel>>;
  update(addressTypeID: number, model: IAddressTypeUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressTypeLookupModel>>;
  update(addressTypeID: number, model: IAddressTypeUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes', {
      addressTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IAddressTypeUpdateModel, IAddressTypeLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IAddressTypeUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IAddressTypeLookupModel>>;
  updateMany(model: Array<IAddressTypeUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IAddressTypeLookupModel>>>;
  updateMany(model: Array<IAddressTypeUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IAddressTypeLookupModel>>>;
  updateMany(model: Array<IAddressTypeUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IAddressTypeUpdateItem>, Array<IAddressTypeLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(addressTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressTypeLookupModel>;
  get(addressTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressTypeLookupModel>>;
  get(addressTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressTypeLookupModel>>;
  get(addressTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes', {
      addressTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IAddressTypeLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressTypesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressTypesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressTypesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('AddressTypes/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IAddressTypesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
