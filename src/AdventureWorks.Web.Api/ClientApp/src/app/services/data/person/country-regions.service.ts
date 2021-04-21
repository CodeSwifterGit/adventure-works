import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICountryRegion } from 'app/models/data/entities/person/country-region/country-region';
import { ICountryRegionLookupModel } from 'app/models/data/entities/person/country-region/country-region-lookup-model';
import { ICountryRegionUpdateModel } from 'app/models/data/entities/person/country-region/country-region-update-model';
import { ICountryRegionsListViewModel } from 'app/models/data/entities/person/country-region/country-regions-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICountryRegionPrimaryKey {
  countryRegionCode: string;
}

export interface ICountryRegionUpdateItem extends ICountryRegion {
  requestTarget: ICountryRegionPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CountryRegionsService {
  constructor(protected apiClient: DataService) {}

  create(model: ICountryRegion, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionLookupModel>;
  create(model: ICountryRegion, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionLookupModel>>;
  create(model: ICountryRegion, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionLookupModel>>;
  create(model: ICountryRegion, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions', {});

    return this.apiClient.create<ICountryRegion, ICountryRegionLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICountryRegion>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICountryRegionLookupModel>>;
  createMany(model: Array<ICountryRegion>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICountryRegionLookupModel>>>;
  createMany(model: Array<ICountryRegion>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICountryRegionLookupModel>>>;
  createMany(model: Array<ICountryRegion>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions/createMany', {});

    return this.apiClient.create<Array<ICountryRegion>, Array<ICountryRegionLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(countryRegionCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(countryRegionCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(countryRegionCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(countryRegionCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions', {
      countryRegionCode,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICountryRegionPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICountryRegionPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICountryRegionPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICountryRegionPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions/DeleteMany', {});

    return this.apiClient.post<Array<ICountryRegionPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(countryRegionCode: string, model: ICountryRegionUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionLookupModel>;
  update(countryRegionCode: string, model: ICountryRegionUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionLookupModel>>;
  update(countryRegionCode: string, model: ICountryRegionUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionLookupModel>>;
  update(countryRegionCode: string, model: ICountryRegionUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions', {
      countryRegionCode,
    });

    return this.apiClient.update<ICountryRegionUpdateModel, ICountryRegionLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICountryRegionUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICountryRegionLookupModel>>;
  updateMany(model: Array<ICountryRegionUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICountryRegionLookupModel>>>;
  updateMany(model: Array<ICountryRegionUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICountryRegionLookupModel>>>;
  updateMany(model: Array<ICountryRegionUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions/UpdateMany', {});

    return this.apiClient.update<Array<ICountryRegionUpdateItem>, Array<ICountryRegionLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(countryRegionCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionLookupModel>;
  get(countryRegionCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionLookupModel>>;
  get(countryRegionCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionLookupModel>>;
  get(countryRegionCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions', {
      countryRegionCode,
    });

    return this.apiClient.get<ICountryRegionLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICountryRegionsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICountryRegionsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICountryRegionsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CountryRegions/all', {});

    return this.apiClient.get<ICountryRegionsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
