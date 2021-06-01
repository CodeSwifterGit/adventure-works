import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IWorkOrder } from 'app/models/data/entities/production/work-order/work-order';
import { IWorkOrderLookupModel } from 'app/models/data/entities/production/work-order/work-order-lookup-model';
import { IWorkOrderUpdateModel } from 'app/models/data/entities/production/work-order/work-order-update-model';
import { IWorkOrdersListViewModel } from 'app/models/data/entities/production/work-order/work-orders-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IWorkOrderPrimaryKey {
  workOrderID: number;
}

export interface IWorkOrderUpdateItem extends IWorkOrder {
  requestTarget: IWorkOrderPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class WorkOrdersService {
  constructor(protected apiClient: DataService) {}

  create(model: IWorkOrder, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderLookupModel>;
  create(model: IWorkOrder, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderLookupModel>>;
  create(model: IWorkOrder, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderLookupModel>>;
  create(model: IWorkOrder, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IWorkOrder, IWorkOrderLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IWorkOrder>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IWorkOrderLookupModel>>;
  createMany(model: Array<IWorkOrder>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IWorkOrderLookupModel>>>;
  createMany(model: Array<IWorkOrder>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IWorkOrderLookupModel>>>;
  createMany(model: Array<IWorkOrder>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IWorkOrder>, Array<IWorkOrderLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(workOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(workOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(workOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(workOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders', {
      workOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IWorkOrderPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IWorkOrderPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IWorkOrderPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IWorkOrderPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IWorkOrderPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(workOrderID: number, model: IWorkOrderUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderLookupModel>;
  update(workOrderID: number, model: IWorkOrderUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderLookupModel>>;
  update(workOrderID: number, model: IWorkOrderUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderLookupModel>>;
  update(workOrderID: number, model: IWorkOrderUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders', {
      workOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IWorkOrderUpdateModel, IWorkOrderLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IWorkOrderUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IWorkOrderLookupModel>>;
  updateMany(model: Array<IWorkOrderUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IWorkOrderLookupModel>>>;
  updateMany(model: Array<IWorkOrderUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IWorkOrderLookupModel>>>;
  updateMany(model: Array<IWorkOrderUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IWorkOrderUpdateItem>, Array<IWorkOrderLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(workOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderLookupModel>;
  get(workOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderLookupModel>>;
  get(workOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderLookupModel>>;
  get(workOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders', {
      workOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IWorkOrderLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrdersListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrdersListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrdersListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders/GetWorkOrdersByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IWorkOrdersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByScrapReason(scrapReasonID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrdersListViewModel>;
  getByScrapReason(scrapReasonID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrdersListViewModel>>;
  getByScrapReason(scrapReasonID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrdersListViewModel>>;
  getByScrapReason(scrapReasonID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrders/GetWorkOrdersByScrapReason', {
      scrapReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IWorkOrdersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
