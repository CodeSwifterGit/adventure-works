import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesTerritory } from 'app/models/data/entities/sales/sales-territory/sales-territory';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';
import { ISalesTerritoryUpdateModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-update-model';
import { ISalesTerritoriesListViewModel } from 'app/models/data/entities/sales/sales-territory/sales-territories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ISalesTerritoryPrimaryKey {
  territoryID: number;
}

export interface ISalesTerritoryUpdateItem extends ISalesTerritory {
  requestTarget: ISalesTerritoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesTerritoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: ISalesTerritory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryLookupModel>;
  create(model: ISalesTerritory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryLookupModel>>;
  create(model: ISalesTerritory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryLookupModel>>;
  create(model: ISalesTerritory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesTerritory, ISalesTerritoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesTerritory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesTerritoryLookupModel>>;
  createMany(model: Array<ISalesTerritory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesTerritoryLookupModel>>>;
  createMany(model: Array<ISalesTerritory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesTerritoryLookupModel>>>;
  createMany(model: Array<ISalesTerritory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesTerritory>, Array<ISalesTerritoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(territoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(territoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(territoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(territoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories', {
      territoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesTerritoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesTerritoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesTerritoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesTerritoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesTerritoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(territoryID: number, model: ISalesTerritoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryLookupModel>;
  update(territoryID: number, model: ISalesTerritoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryLookupModel>>;
  update(territoryID: number, model: ISalesTerritoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryLookupModel>>;
  update(territoryID: number, model: ISalesTerritoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories', {
      territoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesTerritoryUpdateModel, ISalesTerritoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesTerritoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesTerritoryLookupModel>>;
  updateMany(model: Array<ISalesTerritoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesTerritoryLookupModel>>>;
  updateMany(model: Array<ISalesTerritoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesTerritoryLookupModel>>>;
  updateMany(model: Array<ISalesTerritoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesTerritoryUpdateItem>, Array<ISalesTerritoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(territoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryLookupModel>;
  get(territoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryLookupModel>>;
  get(territoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryLookupModel>>;
  get(territoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories', {
      territoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTerritoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoriesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoriesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoriesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritories/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTerritoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
