import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICurrency } from 'app/models/data/entities/sales/currency/currency';
import { ICurrencyLookupModel } from 'app/models/data/entities/sales/currency/currency-lookup-model';
import { ICurrencyUpdateModel } from 'app/models/data/entities/sales/currency/currency-update-model';
import { ICurrenciesListViewModel } from 'app/models/data/entities/sales/currency/currencies-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICurrencyPrimaryKey {
  currencyCode: string;
}

export interface ICurrencyUpdateItem extends ICurrency {
  requestTarget: ICurrencyPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CurrenciesService {
  constructor(protected apiClient: DataService) {}

  create(model: ICurrency, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyLookupModel>;
  create(model: ICurrency, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyLookupModel>>;
  create(model: ICurrency, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyLookupModel>>;
  create(model: ICurrency, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Currencies', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ICurrency, ICurrencyLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICurrency>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICurrencyLookupModel>>;
  createMany(model: Array<ICurrency>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICurrencyLookupModel>>>;
  createMany(model: Array<ICurrency>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICurrencyLookupModel>>>;
  createMany(model: Array<ICurrency>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Currencies/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ICurrency>, Array<ICurrencyLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(currencyCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(currencyCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(currencyCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(currencyCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Currencies', {
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICurrencyPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICurrencyPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICurrencyPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICurrencyPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Currencies/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ICurrencyPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(currencyCode: string, model: ICurrencyUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyLookupModel>;
  update(currencyCode: string, model: ICurrencyUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyLookupModel>>;
  update(currencyCode: string, model: ICurrencyUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyLookupModel>>;
  update(currencyCode: string, model: ICurrencyUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Currencies', {
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ICurrencyUpdateModel, ICurrencyLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICurrencyUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICurrencyLookupModel>>;
  updateMany(model: Array<ICurrencyUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICurrencyLookupModel>>>;
  updateMany(model: Array<ICurrencyUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICurrencyLookupModel>>>;
  updateMany(model: Array<ICurrencyUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Currencies/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ICurrencyUpdateItem>, Array<ICurrencyLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(currencyCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyLookupModel>;
  get(currencyCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyLookupModel>>;
  get(currencyCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyLookupModel>>;
  get(currencyCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Currencies', {
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICurrencyLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrenciesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrenciesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrenciesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Currencies/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<ICurrenciesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
