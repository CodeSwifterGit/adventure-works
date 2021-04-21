import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IPurchaseOrderDetail } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail';
import { IPurchaseOrderDetailLookupModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-lookup-model';
import { IPurchaseOrderDetailUpdateModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-update-model';
import { IPurchaseOrderDetailsListViewModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-details-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IPurchaseOrderDetailPrimaryKey {
  purchaseOrderID: number;
  purchaseOrderDetailID: number;
}

export interface IPurchaseOrderDetailUpdateItem extends IPurchaseOrderDetail {
  requestTarget: IPurchaseOrderDetailPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class PurchaseOrderDetailsService {
  constructor(protected apiClient: DataService) {}

  create(model: IPurchaseOrderDetail, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderDetailLookupModel>;
  create(model: IPurchaseOrderDetail, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderDetailLookupModel>>;
  create(model: IPurchaseOrderDetail, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderDetailLookupModel>>;
  create(model: IPurchaseOrderDetail, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails', {});

    return this.apiClient.create<IPurchaseOrderDetail, IPurchaseOrderDetailLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IPurchaseOrderDetail>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IPurchaseOrderDetailLookupModel>>;
  createMany(model: Array<IPurchaseOrderDetail>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IPurchaseOrderDetailLookupModel>>>;
  createMany(model: Array<IPurchaseOrderDetail>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IPurchaseOrderDetailLookupModel>>>;
  createMany(model: Array<IPurchaseOrderDetail>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails/createMany', {});

    return this.apiClient.create<Array<IPurchaseOrderDetail>, Array<IPurchaseOrderDetailLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails', {
      purchaseOrderID,
      purchaseOrderDetailID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IPurchaseOrderDetailPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IPurchaseOrderDetailPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IPurchaseOrderDetailPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IPurchaseOrderDetailPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails/DeleteMany', {});

    return this.apiClient.post<Array<IPurchaseOrderDetailPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(purchaseOrderID: number, purchaseOrderDetailID: number, model: IPurchaseOrderDetailUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderDetailLookupModel>;
  update(purchaseOrderID: number, purchaseOrderDetailID: number, model: IPurchaseOrderDetailUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderDetailLookupModel>>;
  update(purchaseOrderID: number, purchaseOrderDetailID: number, model: IPurchaseOrderDetailUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderDetailLookupModel>>;
  update(purchaseOrderID: number, purchaseOrderDetailID: number, model: IPurchaseOrderDetailUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails', {
      purchaseOrderID,
      purchaseOrderDetailID,
    });

    return this.apiClient.update<IPurchaseOrderDetailUpdateModel, IPurchaseOrderDetailLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IPurchaseOrderDetailUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IPurchaseOrderDetailLookupModel>>;
  updateMany(model: Array<IPurchaseOrderDetailUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IPurchaseOrderDetailLookupModel>>>;
  updateMany(model: Array<IPurchaseOrderDetailUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IPurchaseOrderDetailLookupModel>>>;
  updateMany(model: Array<IPurchaseOrderDetailUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails/UpdateMany', {});

    return this.apiClient.update<Array<IPurchaseOrderDetailUpdateItem>, Array<IPurchaseOrderDetailLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderDetailLookupModel>;
  get(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderDetailLookupModel>>;
  get(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderDetailLookupModel>>;
  get(purchaseOrderID: number, purchaseOrderDetailID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails', {
      purchaseOrderID,
      purchaseOrderDetailID,
    });

    return this.apiClient.get<IPurchaseOrderDetailLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderDetailsListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderDetailsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderDetailsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails/GetPurchaseOrderDetailsByProduct', {
      productID,
    });

    return this.apiClient.get<IPurchaseOrderDetailsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByPurchaseOrderHeader(purchaseOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderDetailsListViewModel>;
  getByPurchaseOrderHeader(purchaseOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderDetailsListViewModel>>;
  getByPurchaseOrderHeader(purchaseOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderDetailsListViewModel>>;
  getByPurchaseOrderHeader(purchaseOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderDetails/GetPurchaseOrderDetailsByPurchaseOrderHeader', {
      purchaseOrderID,
    });

    return this.apiClient.get<IPurchaseOrderDetailsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
