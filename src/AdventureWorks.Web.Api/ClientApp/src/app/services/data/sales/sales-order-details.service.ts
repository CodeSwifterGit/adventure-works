import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesOrderDetail } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail';
import { ISalesOrderDetailLookupModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-lookup-model';
import { ISalesOrderDetailUpdateModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-update-model';
import { ISalesOrderDetailsListViewModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-details-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface ISalesOrderDetailPrimaryKey {
  salesOrderID: number;
  salesOrderDetailID: number;
}

export interface ISalesOrderDetailUpdateItem extends ISalesOrderDetail {
  requestTarget: ISalesOrderDetailPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesOrderDetailsService {
  constructor(protected apiClient: DataService) { }

  create(model: ISalesOrderDetail, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderDetailLookupModel>;
  create(model: ISalesOrderDetail, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderDetailLookupModel>>;
  create(model: ISalesOrderDetail, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderDetailLookupModel>>;
  create(model: ISalesOrderDetail, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesOrderDetail, ISalesOrderDetailLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesOrderDetail>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesOrderDetailLookupModel>>;
  createMany(model: Array<ISalesOrderDetail>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesOrderDetailLookupModel>>>;
  createMany(model: Array<ISalesOrderDetail>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesOrderDetailLookupModel>>>;
  createMany(model: Array<ISalesOrderDetail>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesOrderDetail>, Array<ISalesOrderDetailLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails', {
      salesOrderID,
      salesOrderDetailID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesOrderDetailPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesOrderDetailPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesOrderDetailPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesOrderDetailPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesOrderDetailPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesOrderID: number, salesOrderDetailID: number, model: ISalesOrderDetailUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderDetailLookupModel>;
  update(salesOrderID: number, salesOrderDetailID: number, model: ISalesOrderDetailUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderDetailLookupModel>>;
  update(salesOrderID: number, salesOrderDetailID: number, model: ISalesOrderDetailUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderDetailLookupModel>>;
  update(salesOrderID: number, salesOrderDetailID: number, model: ISalesOrderDetailUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails', {
      salesOrderID,
      salesOrderDetailID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesOrderDetailUpdateModel, ISalesOrderDetailLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesOrderDetailUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesOrderDetailLookupModel>>;
  updateMany(model: Array<ISalesOrderDetailUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesOrderDetailLookupModel>>>;
  updateMany(model: Array<ISalesOrderDetailUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesOrderDetailLookupModel>>>;
  updateMany(model: Array<ISalesOrderDetailUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesOrderDetailUpdateItem>, Array<ISalesOrderDetailLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderDetailLookupModel>;
  get(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderDetailLookupModel>>;
  get(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderDetailLookupModel>>;
  get(salesOrderID: number, salesOrderDetailID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails', {
      salesOrderID,
      salesOrderDetailID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderDetailLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderDetailsListViewModel>;
  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderDetailsListViewModel>>;
  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderDetailsListViewModel>>;
  getBySalesOrderHeader(salesOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails/GetSalesOrderDetailsBySalesOrderHeader', {
      salesOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderDetailsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySpecialOfferProduct(productID: number, specialOfferID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderDetailsListViewModel>;
  getBySpecialOfferProduct(productID: number, specialOfferID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderDetailsListViewModel>>;
  getBySpecialOfferProduct(productID: number, specialOfferID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderDetailsListViewModel>>;
  getBySpecialOfferProduct(productID: number, specialOfferID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderDetails/GetSalesOrderDetailsBySpecialOfferProduct', {
      productID,
      specialOfferID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderDetailsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
