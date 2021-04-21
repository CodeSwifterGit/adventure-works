import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesReason } from 'app/models/data/entities/sales/sales-reason/sales-reason';
import { ISalesReasonLookupModel } from 'app/models/data/entities/sales/sales-reason/sales-reason-lookup-model';
import { ISalesReasonUpdateModel } from 'app/models/data/entities/sales/sales-reason/sales-reason-update-model';
import { ISalesReasonsListViewModel } from 'app/models/data/entities/sales/sales-reason/sales-reasons-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ISalesReasonPrimaryKey {
  salesReasonID: number;
}

export interface ISalesReasonUpdateItem extends ISalesReason {
  requestTarget: ISalesReasonPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesReasonsService {
  constructor(protected apiClient: DataService) {}

  create(model: ISalesReason, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesReasonLookupModel>;
  create(model: ISalesReason, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesReasonLookupModel>>;
  create(model: ISalesReason, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesReasonLookupModel>>;
  create(model: ISalesReason, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons', {});

    return this.apiClient.create<ISalesReason, ISalesReasonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesReason>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesReasonLookupModel>>;
  createMany(model: Array<ISalesReason>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesReasonLookupModel>>>;
  createMany(model: Array<ISalesReason>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesReasonLookupModel>>>;
  createMany(model: Array<ISalesReason>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons/createMany', {});

    return this.apiClient.create<Array<ISalesReason>, Array<ISalesReasonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons', {
      salesReasonID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesReasonPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesReasonPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesReasonPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesReasonPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons/DeleteMany', {});

    return this.apiClient.post<Array<ISalesReasonPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesReasonID: number, model: ISalesReasonUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesReasonLookupModel>;
  update(salesReasonID: number, model: ISalesReasonUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesReasonLookupModel>>;
  update(salesReasonID: number, model: ISalesReasonUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesReasonLookupModel>>;
  update(salesReasonID: number, model: ISalesReasonUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons', {
      salesReasonID,
    });

    return this.apiClient.update<ISalesReasonUpdateModel, ISalesReasonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesReasonUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesReasonLookupModel>>;
  updateMany(model: Array<ISalesReasonUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesReasonLookupModel>>>;
  updateMany(model: Array<ISalesReasonUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesReasonLookupModel>>>;
  updateMany(model: Array<ISalesReasonUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons/UpdateMany', {});

    return this.apiClient.update<Array<ISalesReasonUpdateItem>, Array<ISalesReasonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesReasonLookupModel>;
  get(salesReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesReasonLookupModel>>;
  get(salesReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesReasonLookupModel>>;
  get(salesReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons', {
      salesReasonID,
    });

    return this.apiClient.get<ISalesReasonLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesReasonsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesReasonsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesReasonsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesReasons/all', {});

    return this.apiClient.get<ISalesReasonsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
