import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICurrencyRate } from 'app/models/data/entities/sales/currency-rate/currency-rate';
import { ICurrencyRateLookupModel } from 'app/models/data/entities/sales/currency-rate/currency-rate-lookup-model';
import { ICurrencyRateUpdateModel } from 'app/models/data/entities/sales/currency-rate/currency-rate-update-model';
import { ICurrencyRatesListViewModel } from 'app/models/data/entities/sales/currency-rate/currency-rates-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICurrencyRatePrimaryKey {
  currencyRateID: number;
}

export interface ICurrencyRateUpdateItem extends ICurrencyRate {
  requestTarget: ICurrencyRatePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CurrencyRatesService {
  constructor(protected apiClient: DataService) {}

  create(model: ICurrencyRate, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyRateLookupModel>;
  create(model: ICurrencyRate, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyRateLookupModel>>;
  create(model: ICurrencyRate, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyRateLookupModel>>;
  create(model: ICurrencyRate, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ICurrencyRate, ICurrencyRateLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICurrencyRate>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICurrencyRateLookupModel>>;
  createMany(model: Array<ICurrencyRate>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICurrencyRateLookupModel>>>;
  createMany(model: Array<ICurrencyRate>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICurrencyRateLookupModel>>>;
  createMany(model: Array<ICurrencyRate>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ICurrencyRate>, Array<ICurrencyRateLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(currencyRateID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(currencyRateID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(currencyRateID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(currencyRateID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates', {
      currencyRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICurrencyRatePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICurrencyRatePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICurrencyRatePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICurrencyRatePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ICurrencyRatePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(currencyRateID: number, model: ICurrencyRateUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyRateLookupModel>;
  update(currencyRateID: number, model: ICurrencyRateUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyRateLookupModel>>;
  update(currencyRateID: number, model: ICurrencyRateUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyRateLookupModel>>;
  update(currencyRateID: number, model: ICurrencyRateUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates', {
      currencyRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ICurrencyRateUpdateModel, ICurrencyRateLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICurrencyRateUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICurrencyRateLookupModel>>;
  updateMany(model: Array<ICurrencyRateUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICurrencyRateLookupModel>>>;
  updateMany(model: Array<ICurrencyRateUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICurrencyRateLookupModel>>>;
  updateMany(model: Array<ICurrencyRateUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ICurrencyRateUpdateItem>, Array<ICurrencyRateLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(currencyRateID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyRateLookupModel>;
  get(currencyRateID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyRateLookupModel>>;
  get(currencyRateID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyRateLookupModel>>;
  get(currencyRateID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates', {
      currencyRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICurrencyRateLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByCurrency(fromCurrencyCode: string, toCurrencyCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICurrencyRatesListViewModel>;
  getByCurrency(fromCurrencyCode: string, toCurrencyCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICurrencyRatesListViewModel>>;
  getByCurrency(fromCurrencyCode: string, toCurrencyCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICurrencyRatesListViewModel>>;
  getByCurrency(fromCurrencyCode: string, toCurrencyCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CurrencyRates/GetCurrencyRatesByCurrency', {
      fromCurrencyCode,
      toCurrencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICurrencyRatesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
