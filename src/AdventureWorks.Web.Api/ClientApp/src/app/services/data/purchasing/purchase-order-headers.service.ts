import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IPurchaseOrderHeader } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header';
import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';
import { IPurchaseOrderHeaderUpdateModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-update-model';
import { IPurchaseOrderHeadersListViewModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-headers-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IPurchaseOrderHeaderPrimaryKey {
  purchaseOrderID: number;
}

export interface IPurchaseOrderHeaderUpdateItem extends IPurchaseOrderHeader {
  requestTarget: IPurchaseOrderHeaderPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class PurchaseOrderHeadersService {
  constructor(protected apiClient: DataService) {}

  create(model: IPurchaseOrderHeader, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderHeaderLookupModel>;
  create(model: IPurchaseOrderHeader, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderHeaderLookupModel>>;
  create(model: IPurchaseOrderHeader, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderHeaderLookupModel>>;
  create(model: IPurchaseOrderHeader, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IPurchaseOrderHeader, IPurchaseOrderHeaderLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IPurchaseOrderHeader>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IPurchaseOrderHeaderLookupModel>>;
  createMany(model: Array<IPurchaseOrderHeader>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IPurchaseOrderHeaderLookupModel>>>;
  createMany(model: Array<IPurchaseOrderHeader>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IPurchaseOrderHeaderLookupModel>>>;
  createMany(model: Array<IPurchaseOrderHeader>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IPurchaseOrderHeader>, Array<IPurchaseOrderHeaderLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(purchaseOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(purchaseOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(purchaseOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(purchaseOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders', {
      purchaseOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IPurchaseOrderHeaderPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IPurchaseOrderHeaderPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IPurchaseOrderHeaderPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IPurchaseOrderHeaderPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IPurchaseOrderHeaderPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(purchaseOrderID: number, model: IPurchaseOrderHeaderUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderHeaderLookupModel>;
  update(purchaseOrderID: number, model: IPurchaseOrderHeaderUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderHeaderLookupModel>>;
  update(purchaseOrderID: number, model: IPurchaseOrderHeaderUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderHeaderLookupModel>>;
  update(purchaseOrderID: number, model: IPurchaseOrderHeaderUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders', {
      purchaseOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IPurchaseOrderHeaderUpdateModel, IPurchaseOrderHeaderLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IPurchaseOrderHeaderUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IPurchaseOrderHeaderLookupModel>>;
  updateMany(model: Array<IPurchaseOrderHeaderUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IPurchaseOrderHeaderLookupModel>>>;
  updateMany(model: Array<IPurchaseOrderHeaderUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IPurchaseOrderHeaderLookupModel>>>;
  updateMany(model: Array<IPurchaseOrderHeaderUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IPurchaseOrderHeaderUpdateItem>, Array<IPurchaseOrderHeaderLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(purchaseOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderHeaderLookupModel>;
  get(purchaseOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderHeaderLookupModel>>;
  get(purchaseOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderHeaderLookupModel>>;
  get(purchaseOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders', {
      purchaseOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IPurchaseOrderHeaderLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderHeadersListViewModel>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderHeadersListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderHeadersListViewModel>>;
  getByEmployee(employeeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders/GetPurchaseOrderHeadersByEmployee', {
      employeeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IPurchaseOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderHeadersListViewModel>;
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderHeadersListViewModel>>;
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderHeadersListViewModel>>;
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders/GetPurchaseOrderHeadersByShipMethod', {
      shipMethodID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IPurchaseOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IPurchaseOrderHeadersListViewModel>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IPurchaseOrderHeadersListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IPurchaseOrderHeadersListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('PurchaseOrderHeaders/GetPurchaseOrderHeadersByVendor', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IPurchaseOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
