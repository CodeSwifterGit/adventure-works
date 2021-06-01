import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICountryRegionCurrency } from 'app/models/data/entities/sales/country-region-currency/country-region-currency';
import { ICountryRegionCurrencyLookupModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-lookup-model';
import { ICountryRegionCurrencyUpdateModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currency-update-model';
import { ICountryRegionCurrenciesListViewModel } from 'app/models/data/entities/sales/country-region-currency/country-region-currencies-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICountryRegionCurrencyPrimaryKey {
  countryRegionCode: string;
  currencyCode: string;
}

export interface ICountryRegionCurrencyUpdateItem extends ICountryRegionCurrency {
  requestTarget: ICountryRegionCurrencyPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CountryRegionCurrenciesService {
  constructor(protected apiClient: DataService) {}

  create(model: ICountryRegionCurrency, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionCurrencyLookupModel>;
  create(model: ICountryRegionCurrency, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionCurrencyLookupModel>>;
  create(model: ICountryRegionCurrency, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionCurrencyLookupModel>>;
  create(model: ICountryRegionCurrency, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ICountryRegionCurrency, ICountryRegionCurrencyLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICountryRegionCurrency>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICountryRegionCurrencyLookupModel>>;
  createMany(model: Array<ICountryRegionCurrency>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICountryRegionCurrencyLookupModel>>>;
  createMany(model: Array<ICountryRegionCurrency>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICountryRegionCurrencyLookupModel>>>;
  createMany(model: Array<ICountryRegionCurrency>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ICountryRegionCurrency>, Array<ICountryRegionCurrencyLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies', {
      countryRegionCode,
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICountryRegionCurrencyPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICountryRegionCurrencyPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICountryRegionCurrencyPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICountryRegionCurrencyPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ICountryRegionCurrencyPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(countryRegionCode: string, currencyCode: string, model: ICountryRegionCurrencyUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionCurrencyLookupModel>;
  update(countryRegionCode: string, currencyCode: string, model: ICountryRegionCurrencyUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionCurrencyLookupModel>>;
  update(countryRegionCode: string, currencyCode: string, model: ICountryRegionCurrencyUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionCurrencyLookupModel>>;
  update(countryRegionCode: string, currencyCode: string, model: ICountryRegionCurrencyUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies', {
      countryRegionCode,
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ICountryRegionCurrencyUpdateModel, ICountryRegionCurrencyLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICountryRegionCurrencyUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICountryRegionCurrencyLookupModel>>;
  updateMany(model: Array<ICountryRegionCurrencyUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICountryRegionCurrencyLookupModel>>>;
  updateMany(model: Array<ICountryRegionCurrencyUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICountryRegionCurrencyLookupModel>>>;
  updateMany(model: Array<ICountryRegionCurrencyUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ICountryRegionCurrencyUpdateItem>, Array<ICountryRegionCurrencyLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionCurrencyLookupModel>;
  get(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionCurrencyLookupModel>>;
  get(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionCurrencyLookupModel>>;
  get(countryRegionCode: string, currencyCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies', {
      countryRegionCode,
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICountryRegionCurrencyLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionCurrenciesListViewModel>;
  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionCurrenciesListViewModel>>;
  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionCurrenciesListViewModel>>;
  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies/GetCountryRegionCurrenciesByCountryRegion', {
      countryRegionCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICountryRegionCurrenciesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCurrency(currencyCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionCurrenciesListViewModel>;
  getByCurrency(currencyCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionCurrenciesListViewModel>>;
  getByCurrency(currencyCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionCurrenciesListViewModel>>;
  getByCurrency(currencyCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegionCurrencies/GetCountryRegionCurrenciesByCurrency', {
      currencyCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICountryRegionCurrenciesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
