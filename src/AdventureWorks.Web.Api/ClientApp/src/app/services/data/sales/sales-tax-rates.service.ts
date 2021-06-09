import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesTaxRate } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate';
import { ISalesTaxRateLookupModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-lookup-model';
import { ISalesTaxRateUpdateModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rate-update-model';
import { ISalesTaxRatesListViewModel } from 'app/models/data/entities/sales/sales-tax-rate/sales-tax-rates-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface ISalesTaxRatePrimaryKey {
  salesTaxRateID: number;
}

export interface ISalesTaxRateUpdateItem extends ISalesTaxRate {
  requestTarget: ISalesTaxRatePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesTaxRatesService {
  constructor(protected apiClient: DataService) { }

  create(model: ISalesTaxRate, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTaxRateLookupModel>;
  create(model: ISalesTaxRate, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTaxRateLookupModel>>;
  create(model: ISalesTaxRate, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTaxRateLookupModel>>;
  create(model: ISalesTaxRate, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesTaxRate, ISalesTaxRateLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesTaxRate>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesTaxRateLookupModel>>;
  createMany(model: Array<ISalesTaxRate>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesTaxRateLookupModel>>>;
  createMany(model: Array<ISalesTaxRate>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesTaxRateLookupModel>>>;
  createMany(model: Array<ISalesTaxRate>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesTaxRate>, Array<ISalesTaxRateLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesTaxRateID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesTaxRateID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesTaxRateID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesTaxRateID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates', {
      salesTaxRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesTaxRatePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesTaxRatePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesTaxRatePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesTaxRatePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesTaxRatePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesTaxRateID: number, model: ISalesTaxRateUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTaxRateLookupModel>;
  update(salesTaxRateID: number, model: ISalesTaxRateUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTaxRateLookupModel>>;
  update(salesTaxRateID: number, model: ISalesTaxRateUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTaxRateLookupModel>>;
  update(salesTaxRateID: number, model: ISalesTaxRateUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates', {
      salesTaxRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesTaxRateUpdateModel, ISalesTaxRateLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesTaxRateUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesTaxRateLookupModel>>;
  updateMany(model: Array<ISalesTaxRateUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesTaxRateLookupModel>>>;
  updateMany(model: Array<ISalesTaxRateUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesTaxRateLookupModel>>>;
  updateMany(model: Array<ISalesTaxRateUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesTaxRateUpdateItem>, Array<ISalesTaxRateLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesTaxRateID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTaxRateLookupModel>;
  get(salesTaxRateID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTaxRateLookupModel>>;
  get(salesTaxRateID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTaxRateLookupModel>>;
  get(salesTaxRateID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates', {
      salesTaxRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTaxRateLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesTaxRatesListViewModel>;
  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesTaxRatesListViewModel>>;
  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesTaxRatesListViewModel>>;
  getByStateProvince(stateProvinceID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesTaxRates/GetSalesTaxRatesByStateProvince', {
      stateProvinceID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesTaxRatesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
