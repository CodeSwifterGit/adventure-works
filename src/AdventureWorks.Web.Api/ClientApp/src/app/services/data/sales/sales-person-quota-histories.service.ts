import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesPersonQuotaHistory } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history';
import { ISalesPersonQuotaHistoryLookupModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-lookup-model';
import { ISalesPersonQuotaHistoryUpdateModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-update-model';
import { ISalesPersonQuotaHistoriesListViewModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-histories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ISalesPersonQuotaHistoryPrimaryKey {
  salesPersonID: number;
  quotaDate: Date | string;
}

export interface ISalesPersonQuotaHistoryUpdateItem extends ISalesPersonQuotaHistory {
  requestTarget: ISalesPersonQuotaHistoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesPersonQuotaHistoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: ISalesPersonQuotaHistory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonQuotaHistoryLookupModel>;
  create(model: ISalesPersonQuotaHistory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonQuotaHistoryLookupModel>>;
  create(model: ISalesPersonQuotaHistory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonQuotaHistoryLookupModel>>;
  create(model: ISalesPersonQuotaHistory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesPersonQuotaHistory, ISalesPersonQuotaHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesPersonQuotaHistory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesPersonQuotaHistoryLookupModel>>;
  createMany(model: Array<ISalesPersonQuotaHistory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesPersonQuotaHistoryLookupModel>>>;
  createMany(model: Array<ISalesPersonQuotaHistory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesPersonQuotaHistoryLookupModel>>>;
  createMany(model: Array<ISalesPersonQuotaHistory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesPersonQuotaHistory>, Array<ISalesPersonQuotaHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories', {
      salesPersonID,
      quotaDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesPersonQuotaHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesPersonQuotaHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesPersonQuotaHistoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesPersonQuotaHistoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesPersonQuotaHistoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesPersonID: number, quotaDate: Date | string, model: ISalesPersonQuotaHistoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonQuotaHistoryLookupModel>;
  update(salesPersonID: number, quotaDate: Date | string, model: ISalesPersonQuotaHistoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonQuotaHistoryLookupModel>>;
  update(salesPersonID: number, quotaDate: Date | string, model: ISalesPersonQuotaHistoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonQuotaHistoryLookupModel>>;
  update(salesPersonID: number, quotaDate: Date | string, model: ISalesPersonQuotaHistoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories', {
      salesPersonID,
      quotaDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesPersonQuotaHistoryUpdateModel, ISalesPersonQuotaHistoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesPersonQuotaHistoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesPersonQuotaHistoryLookupModel>>;
  updateMany(model: Array<ISalesPersonQuotaHistoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesPersonQuotaHistoryLookupModel>>>;
  updateMany(model: Array<ISalesPersonQuotaHistoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesPersonQuotaHistoryLookupModel>>>;
  updateMany(model: Array<ISalesPersonQuotaHistoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesPersonQuotaHistoryUpdateItem>, Array<ISalesPersonQuotaHistoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonQuotaHistoryLookupModel>;
  get(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonQuotaHistoryLookupModel>>;
  get(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonQuotaHistoryLookupModel>>;
  get(salesPersonID: number, quotaDate: Date | string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories', {
      salesPersonID,
      quotaDate,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesPersonQuotaHistoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonQuotaHistoriesListViewModel>;
  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonQuotaHistoriesListViewModel>>;
  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonQuotaHistoriesListViewModel>>;
  getBySalesPerson(salesPersonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPersonQuotaHistories/GetSalesPersonQuotaHistoriesBySalesPerson', {
      salesPersonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesPersonQuotaHistoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
