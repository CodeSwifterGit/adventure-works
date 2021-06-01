import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesTerritoryHistory } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history';
import { ISalesTerritoryHistoryLookupModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-lookup-model';
import { ISalesTerritoryHistoryUpdateModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-update-model';
import { ISalesTerritoryHistoriesListViewModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ISalesTerritoryHistoryPrimaryKey {
  salesPersonID: number;
  territoryID: number;
  startDate: Date | string;
}

export interface ISalesTerritoryHistoryUpdateItem extends ISalesTerritoryHistory {
  requestTarget: ISalesTerritoryHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesTerritoryHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: ISalesTerritoryHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryHistoryLookupModel>;
  create(model: ISalesTerritoryHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryHistoryLookupModel>>;
  create(model: ISalesTerritoryHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryHistoryLookupModel>>;
  create(model: ISalesTerritoryHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesTerritoryHistory, ISalesTerritoryHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesTerritoryHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesTerritoryHistoryLookupModel>>;
  createMany(model: Array<ISalesTerritoryHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesTerritoryHistoryLookupModel>>>;
  createMany(model: Array<ISalesTerritoryHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesTerritoryHistoryLookupModel>>>;
  createMany(model: Array<ISalesTerritoryHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesTerritoryHistory>, Array<ISalesTerritoryHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories', {
      salesPersonID,
      territoryID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesTerritoryHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesTerritoryHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesTerritoryHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesTerritoryHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesTerritoryHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesPersonID: number, territoryID: number, startDate: Date | string, model: ISalesTerritoryHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryHistoryLookupModel>;
  update(salesPersonID: number, territoryID: number, startDate: Date | string, model: ISalesTerritoryHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryHistoryLookupModel>>;
  update(salesPersonID: number, territoryID: number, startDate: Date | string, model: ISalesTerritoryHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryHistoryLookupModel>>;
  update(salesPersonID: number, territoryID: number, startDate: Date | string, model: ISalesTerritoryHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories', {
      salesPersonID,
      territoryID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesTerritoryHistoryUpdateModel, ISalesTerritoryHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesTerritoryHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesTerritoryHistoryLookupModel>>;
  updateMany(model: Array<ISalesTerritoryHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesTerritoryHistoryLookupModel>>>;
  updateMany(model: Array<ISalesTerritoryHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesTerritoryHistoryLookupModel>>>;
  updateMany(model: Array<ISalesTerritoryHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesTerritoryHistoryUpdateItem>, Array<ISalesTerritoryHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryHistoryLookupModel>;
  get(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryHistoryLookupModel>>;
  get(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryHistoryLookupModel>>;
  get(salesPersonID: number, territoryID: number, startDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories', {
      salesPersonID,
      territoryID,
      startDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTerritoryHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryHistoriesListViewModel>;
  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryHistoriesListViewModel>>;
  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryHistoriesListViewModel>>;
  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories/GetSalesTerritoryHistoriesBySalesPerson', {
      salesPersonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTerritoryHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTerritoryHistoriesListViewModel>;
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTerritoryHistoriesListViewModel>>;
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTerritoryHistoriesListViewModel>>;
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTerritoryHistories/GetSalesTerritoryHistoriesBySalesTerritory', {
      territoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTerritoryHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
