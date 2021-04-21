import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IAWBuildVersion } from 'app/models/data/entities/dbo/a-w-build-version/a-w-build-version';
import { IAWBuildVersionLookupModel } from 'app/models/data/entities/dbo/a-w-build-version/a-w-build-version-lookup-model';
import { IAWBuildVersionUpdateModel } from 'app/models/data/entities/dbo/a-w-build-version/a-w-build-version-update-model';
import { IAWBuildVersionsListViewModel } from 'app/models/data/entities/dbo/a-w-build-version/a-w-build-versions-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IAWBuildVersionPrimaryKey {
  systemInformationID: number;
}

export interface IAWBuildVersionUpdateItem extends IAWBuildVersion {
  requestTarget: IAWBuildVersionPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class AWBuildVersionsService {
  constructor(protected apiClient: DataService) {}

  create(model: IAWBuildVersion, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAWBuildVersionLookupModel>;
  create(model: IAWBuildVersion, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAWBuildVersionLookupModel>>;
  create(model: IAWBuildVersion, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAWBuildVersionLookupModel>>;
  create(model: IAWBuildVersion, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions', {});

    return this.apiClient.create<IAWBuildVersion, IAWBuildVersionLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IAWBuildVersion>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IAWBuildVersionLookupModel>>;
  createMany(model: Array<IAWBuildVersion>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IAWBuildVersionLookupModel>>>;
  createMany(model: Array<IAWBuildVersion>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IAWBuildVersionLookupModel>>>;
  createMany(model: Array<IAWBuildVersion>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions/createMany', {});

    return this.apiClient.create<Array<IAWBuildVersion>, Array<IAWBuildVersionLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(systemInformationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(systemInformationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(systemInformationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(systemInformationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions', {
      systemInformationID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IAWBuildVersionPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IAWBuildVersionPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IAWBuildVersionPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IAWBuildVersionPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions/DeleteMany', {});

    return this.apiClient.post<Array<IAWBuildVersionPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(systemInformationID: number, model: IAWBuildVersionUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAWBuildVersionLookupModel>;
  update(systemInformationID: number, model: IAWBuildVersionUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAWBuildVersionLookupModel>>;
  update(systemInformationID: number, model: IAWBuildVersionUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAWBuildVersionLookupModel>>;
  update(systemInformationID: number, model: IAWBuildVersionUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions', {
      systemInformationID,
    });

    return this.apiClient.update<IAWBuildVersionUpdateModel, IAWBuildVersionLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IAWBuildVersionUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IAWBuildVersionLookupModel>>;
  updateMany(model: Array<IAWBuildVersionUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IAWBuildVersionLookupModel>>>;
  updateMany(model: Array<IAWBuildVersionUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IAWBuildVersionLookupModel>>>;
  updateMany(model: Array<IAWBuildVersionUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions/UpdateMany', {});

    return this.apiClient.update<Array<IAWBuildVersionUpdateItem>, Array<IAWBuildVersionLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(systemInformationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAWBuildVersionLookupModel>;
  get(systemInformationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAWBuildVersionLookupModel>>;
  get(systemInformationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAWBuildVersionLookupModel>>;
  get(systemInformationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions', {
      systemInformationID,
    });

    return this.apiClient.get<IAWBuildVersionLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IAWBuildVersionsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IAWBuildVersionsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IAWBuildVersionsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('AWBuildVersions/all', {});

    return this.apiClient.get<IAWBuildVersionsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
