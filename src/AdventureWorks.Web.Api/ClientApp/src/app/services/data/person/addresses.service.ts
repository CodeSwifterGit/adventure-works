import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IAddress } from 'app/models/data/entities/person/address/address';
import { IAddressLookupModel } from 'app/models/data/entities/person/address/address-lookup-model';
import { IAddressUpdateModel } from 'app/models/data/entities/person/address/address-update-model';
import { IAddressesListViewModel } from 'app/models/data/entities/person/address/addresses-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IAddressPrimaryKey {
  addressID: number;
}

export interface IAddressUpdateItem extends IAddress {
  requestTarget: IAddressPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class AddressesService {
  constructor(protected apiClient: DataService) { }

  create(model: IAddress, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressLookupModel>;
  create(model: IAddress, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressLookupModel>>;
  create(model: IAddress, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressLookupModel>>;
  create(model: IAddress, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Addresses', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IAddress, IAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IAddress>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IAddressLookupModel>>;
  createMany(model: Array<IAddress>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IAddressLookupModel>>>;
  createMany(model: Array<IAddress>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IAddressLookupModel>>>;
  createMany(model: Array<IAddress>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Addresses/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IAddress>, Array<IAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Addresses', {
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IAddressPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IAddressPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IAddressPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IAddressPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Addresses/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IAddressPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(addressID: number, model: IAddressUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressLookupModel>;
  update(addressID: number, model: IAddressUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressLookupModel>>;
  update(addressID: number, model: IAddressUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressLookupModel>>;
  update(addressID: number, model: IAddressUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Addresses', {
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IAddressUpdateModel, IAddressLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IAddressUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IAddressLookupModel>>;
  updateMany(model: Array<IAddressUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IAddressLookupModel>>>;
  updateMany(model: Array<IAddressUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IAddressLookupModel>>>;
  updateMany(model: Array<IAddressUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Addresses/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IAddressUpdateItem>, Array<IAddressLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(addressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressLookupModel>;
  get(addressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressLookupModel>>;
  get(addressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressLookupModel>>;
  get(addressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Addresses', {
      addressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IAddressLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAddressesListViewModel>;
  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAddressesListViewModel>>;
  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAddressesListViewModel>>;
  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Addresses/GetAddressesByStateProvince', {
      stateProvinceID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IAddressesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
