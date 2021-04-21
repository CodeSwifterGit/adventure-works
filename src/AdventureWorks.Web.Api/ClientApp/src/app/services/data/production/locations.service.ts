import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ILocation } from 'app/models/data/entities/production/location/location';
import { ILocationLookupModel } from 'app/models/data/entities/production/location/location-lookup-model';
import { ILocationUpdateModel } from 'app/models/data/entities/production/location/location-update-model';
import { ILocationsListViewModel } from 'app/models/data/entities/production/location/locations-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ILocationPrimaryKey {
  locationID: number;
}

export interface ILocationUpdateItem extends ILocation {
  requestTarget: ILocationPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class LocationsService {
  constructor(protected apiClient: DataService) {}

  create(model: ILocation, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ILocationLookupModel>;
  create(model: ILocation, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ILocationLookupModel>>;
  create(model: ILocation, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ILocationLookupModel>>;
  create(model: ILocation, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Locations', {});

    return this.apiClient.create<ILocation, ILocationLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ILocation>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ILocationLookupModel>>;
  createMany(model: Array<ILocation>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ILocationLookupModel>>>;
  createMany(model: Array<ILocation>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ILocationLookupModel>>>;
  createMany(model: Array<ILocation>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Locations/createMany', {});

    return this.apiClient.create<Array<ILocation>, Array<ILocationLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(locationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(locationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(locationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(locationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Locations', {
      locationID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ILocationPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ILocationPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ILocationPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ILocationPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Locations/DeleteMany', {});

    return this.apiClient.post<Array<ILocationPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(locationID: number, model: ILocationUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ILocationLookupModel>;
  update(locationID: number, model: ILocationUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ILocationLookupModel>>;
  update(locationID: number, model: ILocationUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ILocationLookupModel>>;
  update(locationID: number, model: ILocationUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Locations', {
      locationID,
    });

    return this.apiClient.update<ILocationUpdateModel, ILocationLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ILocationUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ILocationLookupModel>>;
  updateMany(model: Array<ILocationUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ILocationLookupModel>>>;
  updateMany(model: Array<ILocationUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ILocationLookupModel>>>;
  updateMany(model: Array<ILocationUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Locations/UpdateMany', {});

    return this.apiClient.update<Array<ILocationUpdateItem>, Array<ILocationLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(locationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ILocationLookupModel>;
  get(locationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ILocationLookupModel>>;
  get(locationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ILocationLookupModel>>;
  get(locationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Locations', {
      locationID,
    });

    return this.apiClient.get<ILocationLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ILocationsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ILocationsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ILocationsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Locations/all', {});

    return this.apiClient.get<ILocationsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
