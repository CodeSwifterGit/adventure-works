import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IIllustration } from 'app/models/data/entities/production/illustration/illustration';
import { IIllustrationLookupModel } from 'app/models/data/entities/production/illustration/illustration-lookup-model';
import { IIllustrationUpdateModel } from 'app/models/data/entities/production/illustration/illustration-update-model';
import { IIllustrationsListViewModel } from 'app/models/data/entities/production/illustration/illustrations-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IIllustrationPrimaryKey {
  illustrationID: number;
}

export interface IIllustrationUpdateItem extends IIllustration {
  requestTarget: IIllustrationPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class IllustrationsService {
  constructor(protected apiClient: DataService) { }

  create(model: IIllustration, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIllustrationLookupModel>;
  create(model: IIllustration, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIllustrationLookupModel>>;
  create(model: IIllustration, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIllustrationLookupModel>>;
  create(model: IIllustration, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Illustrations', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IIllustration, IIllustrationLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IIllustration>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IIllustrationLookupModel>>;
  createMany(model: Array<IIllustration>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IIllustrationLookupModel>>>;
  createMany(model: Array<IIllustration>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IIllustrationLookupModel>>>;
  createMany(model: Array<IIllustration>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Illustrations/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IIllustration>, Array<IIllustrationLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(illustrationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(illustrationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(illustrationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(illustrationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Illustrations', {
      illustrationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IIllustrationPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IIllustrationPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IIllustrationPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IIllustrationPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Illustrations/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IIllustrationPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(illustrationID: number, model: IIllustrationUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIllustrationLookupModel>;
  update(illustrationID: number, model: IIllustrationUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIllustrationLookupModel>>;
  update(illustrationID: number, model: IIllustrationUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIllustrationLookupModel>>;
  update(illustrationID: number, model: IIllustrationUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Illustrations', {
      illustrationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IIllustrationUpdateModel, IIllustrationLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IIllustrationUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IIllustrationLookupModel>>;
  updateMany(model: Array<IIllustrationUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IIllustrationLookupModel>>>;
  updateMany(model: Array<IIllustrationUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IIllustrationLookupModel>>>;
  updateMany(model: Array<IIllustrationUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Illustrations/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IIllustrationUpdateItem>, Array<IIllustrationLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(illustrationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIllustrationLookupModel>;
  get(illustrationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIllustrationLookupModel>>;
  get(illustrationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIllustrationLookupModel>>;
  get(illustrationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Illustrations', {
      illustrationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IIllustrationLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIllustrationsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIllustrationsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIllustrationsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Illustrations/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IIllustrationsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
