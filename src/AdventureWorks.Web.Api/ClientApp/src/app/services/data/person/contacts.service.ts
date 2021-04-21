import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IContact } from 'app/models/data/entities/person/contact/contact';
import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { IContactUpdateModel } from 'app/models/data/entities/person/contact/contact-update-model';
import { IContactsListViewModel } from 'app/models/data/entities/person/contact/contacts-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IContactPrimaryKey {
  contactID: number;
}

export interface IContactUpdateItem extends IContact {
  requestTarget: IContactPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ContactsService {
  constructor(protected apiClient: DataService) {}

  create(model: IContact, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactLookupModel>;
  create(model: IContact, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactLookupModel>>;
  create(model: IContact, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactLookupModel>>;
  create(model: IContact, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Contacts', {});

    return this.apiClient.create<IContact, IContactLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IContact>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IContactLookupModel>>;
  createMany(model: Array<IContact>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IContactLookupModel>>>;
  createMany(model: Array<IContact>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IContactLookupModel>>>;
  createMany(model: Array<IContact>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Contacts/createMany', {});

    return this.apiClient.create<Array<IContact>, Array<IContactLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Contacts', {
      contactID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IContactPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IContactPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IContactPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IContactPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Contacts/DeleteMany', {});

    return this.apiClient.post<Array<IContactPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(contactID: number, model: IContactUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactLookupModel>;
  update(contactID: number, model: IContactUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactLookupModel>>;
  update(contactID: number, model: IContactUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactLookupModel>>;
  update(contactID: number, model: IContactUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Contacts', {
      contactID,
    });

    return this.apiClient.update<IContactUpdateModel, IContactLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IContactUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IContactLookupModel>>;
  updateMany(model: Array<IContactUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IContactLookupModel>>>;
  updateMany(model: Array<IContactUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IContactLookupModel>>>;
  updateMany(model: Array<IContactUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Contacts/UpdateMany', {});

    return this.apiClient.update<Array<IContactUpdateItem>, Array<IContactLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactLookupModel>;
  get(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactLookupModel>>;
  get(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactLookupModel>>;
  get(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Contacts', {
      contactID,
    });

    return this.apiClient.get<IContactLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Contacts/all', {});

    return this.apiClient.get<IContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
