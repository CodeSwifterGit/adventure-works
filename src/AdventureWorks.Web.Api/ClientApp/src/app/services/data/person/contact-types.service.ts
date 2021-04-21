import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IContactType } from 'app/models/data/entities/person/contact-type/contact-type';
import { IContactTypeLookupModel } from 'app/models/data/entities/person/contact-type/contact-type-lookup-model';
import { IContactTypeUpdateModel } from 'app/models/data/entities/person/contact-type/contact-type-update-model';
import { IContactTypesListViewModel } from 'app/models/data/entities/person/contact-type/contact-types-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IContactTypePrimaryKey {
  contactTypeID: number;
}

export interface IContactTypeUpdateItem extends IContactType {
  requestTarget: IContactTypePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ContactTypesService {
  constructor(protected apiClient: DataService) {}

  create(model: IContactType, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactTypeLookupModel>;
  create(model: IContactType, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactTypeLookupModel>>;
  create(model: IContactType, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactTypeLookupModel>>;
  create(model: IContactType, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes', {});

    return this.apiClient.create<IContactType, IContactTypeLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IContactType>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IContactTypeLookupModel>>;
  createMany(model: Array<IContactType>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IContactTypeLookupModel>>>;
  createMany(model: Array<IContactType>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IContactTypeLookupModel>>>;
  createMany(model: Array<IContactType>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes/createMany', {});

    return this.apiClient.create<Array<IContactType>, Array<IContactTypeLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(contactTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(contactTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(contactTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(contactTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes', {
      contactTypeID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IContactTypePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IContactTypePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IContactTypePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IContactTypePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes/DeleteMany', {});

    return this.apiClient.post<Array<IContactTypePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(contactTypeID: number, model: IContactTypeUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactTypeLookupModel>;
  update(contactTypeID: number, model: IContactTypeUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactTypeLookupModel>>;
  update(contactTypeID: number, model: IContactTypeUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactTypeLookupModel>>;
  update(contactTypeID: number, model: IContactTypeUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes', {
      contactTypeID,
    });

    return this.apiClient.update<IContactTypeUpdateModel, IContactTypeLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IContactTypeUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IContactTypeLookupModel>>;
  updateMany(model: Array<IContactTypeUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IContactTypeLookupModel>>>;
  updateMany(model: Array<IContactTypeUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IContactTypeLookupModel>>>;
  updateMany(model: Array<IContactTypeUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes/UpdateMany', {});

    return this.apiClient.update<Array<IContactTypeUpdateItem>, Array<IContactTypeLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(contactTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactTypeLookupModel>;
  get(contactTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactTypeLookupModel>>;
  get(contactTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactTypeLookupModel>>;
  get(contactTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes', {
      contactTypeID,
    });

    return this.apiClient.get<IContactTypeLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactTypesListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactTypesListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactTypesListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactTypes/all', {});

    return this.apiClient.get<IContactTypesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
