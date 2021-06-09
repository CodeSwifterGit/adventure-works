import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesOrderHeaderSalesReason } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason';
import { ISalesOrderHeaderSalesReasonLookupModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-lookup-model';
import { ISalesOrderHeaderSalesReasonUpdateModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-update-model';
import { ISalesOrderHeaderSalesReasonsListViewModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reasons-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface ISalesOrderHeaderSalesReasonPrimaryKey {
  salesOrderID: number;
  salesReasonID: number;
}

export interface ISalesOrderHeaderSalesReasonUpdateItem extends ISalesOrderHeaderSalesReason {
  requestTarget: ISalesOrderHeaderSalesReasonPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesOrderHeaderSalesReasonsService {
  constructor(protected apiClient: DataService) { }

  create(model: ISalesOrderHeaderSalesReason, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderSalesReasonLookupModel>;
  create(model: ISalesOrderHeaderSalesReason, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderSalesReasonLookupModel>>;
  create(model: ISalesOrderHeaderSalesReason, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderSalesReasonLookupModel>>;
  create(model: ISalesOrderHeaderSalesReason, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesOrderHeaderSalesReason, ISalesOrderHeaderSalesReasonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesOrderHeaderSalesReason>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesOrderHeaderSalesReasonLookupModel>>;
  createMany(model: Array<ISalesOrderHeaderSalesReason>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesOrderHeaderSalesReasonLookupModel>>>;
  createMany(model: Array<ISalesOrderHeaderSalesReason>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesOrderHeaderSalesReasonLookupModel>>>;
  createMany(model: Array<ISalesOrderHeaderSalesReason>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesOrderHeaderSalesReason>, Array<ISalesOrderHeaderSalesReasonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons', {
      salesOrderID,
      salesReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesOrderHeaderSalesReasonPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesOrderHeaderSalesReasonPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesOrderHeaderSalesReasonPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesOrderHeaderSalesReasonPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesOrderHeaderSalesReasonPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesOrderID: number, salesReasonID: number, model: ISalesOrderHeaderSalesReasonUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderSalesReasonLookupModel>;
  update(salesOrderID: number, salesReasonID: number, model: ISalesOrderHeaderSalesReasonUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderSalesReasonLookupModel>>;
  update(salesOrderID: number, salesReasonID: number, model: ISalesOrderHeaderSalesReasonUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderSalesReasonLookupModel>>;
  update(salesOrderID: number, salesReasonID: number, model: ISalesOrderHeaderSalesReasonUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons', {
      salesOrderID,
      salesReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesOrderHeaderSalesReasonUpdateModel, ISalesOrderHeaderSalesReasonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesOrderHeaderSalesReasonUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesOrderHeaderSalesReasonLookupModel>>;
  updateMany(model: Array<ISalesOrderHeaderSalesReasonUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesOrderHeaderSalesReasonLookupModel>>>;
  updateMany(model: Array<ISalesOrderHeaderSalesReasonUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesOrderHeaderSalesReasonLookupModel>>>;
  updateMany(model: Array<ISalesOrderHeaderSalesReasonUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesOrderHeaderSalesReasonUpdateItem>, Array<ISalesOrderHeaderSalesReasonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderSalesReasonLookupModel>;
  get(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderSalesReasonLookupModel>>;
  get(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderSalesReasonLookupModel>>;
  get(salesOrderID: number, salesReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons', {
      salesOrderID,
      salesReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeaderSalesReasonLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderSalesReasonsListViewModel>;
  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderSalesReasonsListViewModel>>;
  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderSalesReasonsListViewModel>>;
  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons/GetSalesOrderHeaderSalesReasonsBySalesOrderHeader', {
      salesOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeaderSalesReasonsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesReason(salesReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderSalesReasonsListViewModel>;
  getBySalesReason(salesReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderSalesReasonsListViewModel>>;
  getBySalesReason(salesReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderSalesReasonsListViewModel>>;
  getBySalesReason(salesReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaderSalesReasons/GetSalesOrderHeaderSalesReasonsBySalesReason', {
      salesReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeaderSalesReasonsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
