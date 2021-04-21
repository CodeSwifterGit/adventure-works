import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IStore } from 'app/models/data/entities/sales/store/store';
import { IStoreLookupModel } from 'app/models/data/entities/sales/store/store-lookup-model';
import { IStoreUpdateModel } from 'app/models/data/entities/sales/store/store-update-model';
import { IStoresListViewModel } from 'app/models/data/entities/sales/store/stores-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IStorePrimaryKey {
  customerID: number;
}

export interface IStoreUpdateItem extends IStore {
  requestTarget: IStorePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class StoresService {
  constructor(protected apiClient: DataService) {}

  create(model: IStore, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreLookupModel>;
  create(model: IStore, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreLookupModel>>;
  create(model: IStore, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreLookupModel>>;
  create(model: IStore, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Stores', {});

    return this.apiClient.create<IStore, IStoreLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IStore>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IStoreLookupModel>>;
  createMany(model: Array<IStore>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IStoreLookupModel>>>;
  createMany(model: Array<IStore>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IStoreLookupModel>>>;
  createMany(model: Array<IStore>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Stores/createMany', {});

    return this.apiClient.create<Array<IStore>, Array<IStoreLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Stores', {
      customerID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IStorePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IStorePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IStorePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IStorePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Stores/DeleteMany', {});

    return this.apiClient.post<Array<IStorePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(customerID: number, model: IStoreUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreLookupModel>;
  update(customerID: number, model: IStoreUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreLookupModel>>;
  update(customerID: number, model: IStoreUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreLookupModel>>;
  update(customerID: number, model: IStoreUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Stores', {
      customerID,
    });

    return this.apiClient.update<IStoreUpdateModel, IStoreLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IStoreUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IStoreLookupModel>>;
  updateMany(model: Array<IStoreUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IStoreLookupModel>>>;
  updateMany(model: Array<IStoreUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IStoreLookupModel>>>;
  updateMany(model: Array<IStoreUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Stores/UpdateMany', {});

    return this.apiClient.update<Array<IStoreUpdateItem>, Array<IStoreLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreLookupModel>;
  get(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreLookupModel>>;
  get(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreLookupModel>>;
  get(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Stores', {
      customerID,
    });

    return this.apiClient.get<IStoreLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoresListViewModel>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoresListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoresListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Stores/GetStoresByCustomer', {
      customerID,
    });

    return this.apiClient.get<IStoresListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoresListViewModel>;
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoresListViewModel>>;
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoresListViewModel>>;
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Stores/GetStoresBySalesPerson', {
      salesPersonID,
    });

    return this.apiClient.get<IStoresListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
