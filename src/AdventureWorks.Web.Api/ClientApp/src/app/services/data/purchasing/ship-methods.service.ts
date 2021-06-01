import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IShipMethod } from 'app/models/data/entities/purchasing/ship-method/ship-method';
import { IShipMethodLookupModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-lookup-model';
import { IShipMethodUpdateModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-update-model';
import { IShipMethodsListViewModel } from 'app/models/data/entities/purchasing/ship-method/ship-methods-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IShipMethodPrimaryKey {
  shipMethodID: number;
}

export interface IShipMethodUpdateItem extends IShipMethod {
  requestTarget: IShipMethodPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ShipMethodsService {
  constructor(protected apiClient: DataService) {}

  create(model: IShipMethod, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShipMethodLookupModel>;
  create(model: IShipMethod, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShipMethodLookupModel>>;
  create(model: IShipMethod, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShipMethodLookupModel>>;
  create(model: IShipMethod, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IShipMethod, IShipMethodLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IShipMethod>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IShipMethodLookupModel>>;
  createMany(model: Array<IShipMethod>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IShipMethodLookupModel>>>;
  createMany(model: Array<IShipMethod>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IShipMethodLookupModel>>>;
  createMany(model: Array<IShipMethod>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IShipMethod>, Array<IShipMethodLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(shipMethodID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(shipMethodID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(shipMethodID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(shipMethodID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods', {
      shipMethodID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IShipMethodPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IShipMethodPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IShipMethodPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IShipMethodPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IShipMethodPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(shipMethodID: number, model: IShipMethodUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShipMethodLookupModel>;
  update(shipMethodID: number, model: IShipMethodUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShipMethodLookupModel>>;
  update(shipMethodID: number, model: IShipMethodUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShipMethodLookupModel>>;
  update(shipMethodID: number, model: IShipMethodUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods', {
      shipMethodID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IShipMethodUpdateModel, IShipMethodLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IShipMethodUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IShipMethodLookupModel>>;
  updateMany(model: Array<IShipMethodUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IShipMethodLookupModel>>>;
  updateMany(model: Array<IShipMethodUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IShipMethodLookupModel>>>;
  updateMany(model: Array<IShipMethodUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IShipMethodUpdateItem>, Array<IShipMethodLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(shipMethodID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShipMethodLookupModel>;
  get(shipMethodID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShipMethodLookupModel>>;
  get(shipMethodID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShipMethodLookupModel>>;
  get(shipMethodID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods', {
      shipMethodID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IShipMethodLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShipMethodsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShipMethodsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShipMethodsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ShipMethods/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IShipMethodsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
