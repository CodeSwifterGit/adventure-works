import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IScrapReason } from 'app/models/data/entities/production/scrap-reason/scrap-reason';
import { IScrapReasonLookupModel } from 'app/models/data/entities/production/scrap-reason/scrap-reason-lookup-model';
import { IScrapReasonUpdateModel } from 'app/models/data/entities/production/scrap-reason/scrap-reason-update-model';
import { IScrapReasonsListViewModel } from 'app/models/data/entities/production/scrap-reason/scrap-reasons-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IScrapReasonPrimaryKey {
  scrapReasonID: number;
}

export interface IScrapReasonUpdateItem extends IScrapReason {
  requestTarget: IScrapReasonPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ScrapReasonsService {
  constructor(protected apiClient: DataService) { }

  create(model: IScrapReason, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IScrapReasonLookupModel>;
  create(model: IScrapReason, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IScrapReasonLookupModel>>;
  create(model: IScrapReason, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IScrapReasonLookupModel>>;
  create(model: IScrapReason, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IScrapReason, IScrapReasonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IScrapReason>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IScrapReasonLookupModel>>;
  createMany(model: Array<IScrapReason>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IScrapReasonLookupModel>>>;
  createMany(model: Array<IScrapReason>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IScrapReasonLookupModel>>>;
  createMany(model: Array<IScrapReason>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IScrapReason>, Array<IScrapReasonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(scrapReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(scrapReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(scrapReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(scrapReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons', {
      scrapReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IScrapReasonPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IScrapReasonPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IScrapReasonPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IScrapReasonPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IScrapReasonPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(scrapReasonID: number, model: IScrapReasonUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IScrapReasonLookupModel>;
  update(scrapReasonID: number, model: IScrapReasonUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IScrapReasonLookupModel>>;
  update(scrapReasonID: number, model: IScrapReasonUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IScrapReasonLookupModel>>;
  update(scrapReasonID: number, model: IScrapReasonUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons', {
      scrapReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IScrapReasonUpdateModel, IScrapReasonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IScrapReasonUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IScrapReasonLookupModel>>;
  updateMany(model: Array<IScrapReasonUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IScrapReasonLookupModel>>>;
  updateMany(model: Array<IScrapReasonUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IScrapReasonLookupModel>>>;
  updateMany(model: Array<IScrapReasonUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IScrapReasonUpdateItem>, Array<IScrapReasonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(scrapReasonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IScrapReasonLookupModel>;
  get(scrapReasonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IScrapReasonLookupModel>>;
  get(scrapReasonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IScrapReasonLookupModel>>;
  get(scrapReasonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons', {
      scrapReasonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IScrapReasonLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IScrapReasonsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IScrapReasonsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IScrapReasonsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ScrapReasons/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IScrapReasonsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
