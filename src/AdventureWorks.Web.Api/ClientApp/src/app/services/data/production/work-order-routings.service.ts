import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IWorkOrderRouting } from 'app/models/data/entities/production/work-order-routing/work-order-routing';
import { IWorkOrderRoutingLookupModel } from 'app/models/data/entities/production/work-order-routing/work-order-routing-lookup-model';
import { IWorkOrderRoutingUpdateModel } from 'app/models/data/entities/production/work-order-routing/work-order-routing-update-model';
import { IWorkOrderRoutingsListViewModel } from 'app/models/data/entities/production/work-order-routing/work-order-routings-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IWorkOrderRoutingPrimaryKey {
  workOrderID: number;
  productID: number;
  operationSequence: number;
}

export interface IWorkOrderRoutingUpdateItem extends IWorkOrderRouting {
  requestTarget: IWorkOrderRoutingPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class WorkOrderRoutingsService {
  constructor(protected apiClient: DataService) {}

  create(model: IWorkOrderRouting, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderRoutingLookupModel>;
  create(model: IWorkOrderRouting, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderRoutingLookupModel>>;
  create(model: IWorkOrderRouting, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderRoutingLookupModel>>;
  create(model: IWorkOrderRouting, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IWorkOrderRouting, IWorkOrderRoutingLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IWorkOrderRouting>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IWorkOrderRoutingLookupModel>>;
  createMany(model: Array<IWorkOrderRouting>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IWorkOrderRoutingLookupModel>>>;
  createMany(model: Array<IWorkOrderRouting>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IWorkOrderRoutingLookupModel>>>;
  createMany(model: Array<IWorkOrderRouting>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IWorkOrderRouting>, Array<IWorkOrderRoutingLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings', {
      workOrderID,
      productID,
      operationSequence,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IWorkOrderRoutingPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IWorkOrderRoutingPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IWorkOrderRoutingPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IWorkOrderRoutingPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IWorkOrderRoutingPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(workOrderID: number, productID: number, operationSequence: number, model: IWorkOrderRoutingUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderRoutingLookupModel>;
  update(workOrderID: number, productID: number, operationSequence: number, model: IWorkOrderRoutingUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderRoutingLookupModel>>;
  update(workOrderID: number, productID: number, operationSequence: number, model: IWorkOrderRoutingUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderRoutingLookupModel>>;
  update(workOrderID: number, productID: number, operationSequence: number, model: IWorkOrderRoutingUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings', {
      workOrderID,
      productID,
      operationSequence,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IWorkOrderRoutingUpdateModel, IWorkOrderRoutingLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IWorkOrderRoutingUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IWorkOrderRoutingLookupModel>>;
  updateMany(model: Array<IWorkOrderRoutingUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IWorkOrderRoutingLookupModel>>>;
  updateMany(model: Array<IWorkOrderRoutingUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IWorkOrderRoutingLookupModel>>>;
  updateMany(model: Array<IWorkOrderRoutingUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IWorkOrderRoutingUpdateItem>, Array<IWorkOrderRoutingLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderRoutingLookupModel>;
  get(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderRoutingLookupModel>>;
  get(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderRoutingLookupModel>>;
  get(workOrderID: number, productID: number, operationSequence: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings', {
      workOrderID,
      productID,
      operationSequence,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IWorkOrderRoutingLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByLocation(locationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderRoutingsListViewModel>;
  getByLocation(locationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderRoutingsListViewModel>>;
  getByLocation(locationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderRoutingsListViewModel>>;
  getByLocation(locationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings/GetWorkOrderRoutingsByLocation', {
      locationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IWorkOrderRoutingsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByWorkOrder(workOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IWorkOrderRoutingsListViewModel>;
  getByWorkOrder(workOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IWorkOrderRoutingsListViewModel>>;
  getByWorkOrder(workOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IWorkOrderRoutingsListViewModel>>;
  getByWorkOrder(workOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('WorkOrderRoutings/GetWorkOrderRoutingsByWorkOrder', {
      workOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IWorkOrderRoutingsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
