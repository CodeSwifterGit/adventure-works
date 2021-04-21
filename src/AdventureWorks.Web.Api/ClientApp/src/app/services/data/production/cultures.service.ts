import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICulture } from 'app/models/data/entities/production/culture/culture';
import { ICultureLookupModel } from 'app/models/data/entities/production/culture/culture-lookup-model';
import { ICultureUpdateModel } from 'app/models/data/entities/production/culture/culture-update-model';
import { ICulturesListViewModel } from 'app/models/data/entities/production/culture/cultures-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ICulturePrimaryKey {
  cultureID: string;
}

export interface ICultureUpdateItem extends ICulture {
  requestTarget: ICulturePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CulturesService {
  constructor(protected apiClient: DataService) {}

  create(model: ICulture, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICultureLookupModel>;
  create(model: ICulture, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICultureLookupModel>>;
  create(model: ICulture, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICultureLookupModel>>;
  create(model: ICulture, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Cultures', {});

    return this.apiClient.create<ICulture, ICultureLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICulture>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICultureLookupModel>>;
  createMany(model: Array<ICulture>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICultureLookupModel>>>;
  createMany(model: Array<ICulture>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICultureLookupModel>>>;
  createMany(model: Array<ICulture>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Cultures/createMany', {});

    return this.apiClient.create<Array<ICulture>, Array<ICultureLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(cultureID: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(cultureID: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(cultureID: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(cultureID: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Cultures', {
      cultureID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICulturePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICulturePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICulturePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICulturePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Cultures/DeleteMany', {});

    return this.apiClient.post<Array<ICulturePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(cultureID: string, model: ICultureUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICultureLookupModel>;
  update(cultureID: string, model: ICultureUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICultureLookupModel>>;
  update(cultureID: string, model: ICultureUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICultureLookupModel>>;
  update(cultureID: string, model: ICultureUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Cultures', {
      cultureID,
    });

    return this.apiClient.update<ICultureUpdateModel, ICultureLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICultureUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICultureLookupModel>>;
  updateMany(model: Array<ICultureUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICultureLookupModel>>>;
  updateMany(model: Array<ICultureUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICultureLookupModel>>>;
  updateMany(model: Array<ICultureUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Cultures/UpdateMany', {});

    return this.apiClient.update<Array<ICultureUpdateItem>, Array<ICultureLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(cultureID: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICultureLookupModel>;
  get(cultureID: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICultureLookupModel>>;
  get(cultureID: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICultureLookupModel>>;
  get(cultureID: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Cultures', {
      cultureID,
    });

    return this.apiClient.get<ICultureLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICulturesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICulturesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICulturesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Cultures/all', {});

    return this.apiClient.get<ICulturesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
