import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IVendor } from 'app/models/data/entities/purchasing/vendor/vendor';
import { IVendorLookupModel } from 'app/models/data/entities/purchasing/vendor/vendor-lookup-model';
import { IVendorUpdateModel } from 'app/models/data/entities/purchasing/vendor/vendor-update-model';
import { IVendorsListViewModel } from 'app/models/data/entities/purchasing/vendor/vendors-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IVendorPrimaryKey {
  vendorID: number;
}

export interface IVendorUpdateItem extends IVendor {
  requestTarget: IVendorPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class VendorsService {
  constructor(protected apiClient: DataService) {}

  create(model: IVendor, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorLookupModel>;
  create(model: IVendor, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorLookupModel>>;
  create(model: IVendor, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorLookupModel>>;
  create(model: IVendor, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Vendors', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IVendor, IVendorLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IVendor>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IVendorLookupModel>>;
  createMany(model: Array<IVendor>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IVendorLookupModel>>>;
  createMany(model: Array<IVendor>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IVendorLookupModel>>>;
  createMany(model: Array<IVendor>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Vendors/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IVendor>, Array<IVendorLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Vendors', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IVendorPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IVendorPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IVendorPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IVendorPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Vendors/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IVendorPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(vendorID: number, model: IVendorUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorLookupModel>;
  update(vendorID: number, model: IVendorUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorLookupModel>>;
  update(vendorID: number, model: IVendorUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorLookupModel>>;
  update(vendorID: number, model: IVendorUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Vendors', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IVendorUpdateModel, IVendorLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IVendorUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IVendorLookupModel>>;
  updateMany(model: Array<IVendorUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IVendorLookupModel>>>;
  updateMany(model: Array<IVendorUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IVendorLookupModel>>>;
  updateMany(model: Array<IVendorUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Vendors/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IVendorUpdateItem>, Array<IVendorLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorLookupModel>;
  get(vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorLookupModel>>;
  get(vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorLookupModel>>;
  get(vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Vendors', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Vendors/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
