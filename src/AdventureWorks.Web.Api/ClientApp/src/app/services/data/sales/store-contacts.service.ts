import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IStoreContact } from 'app/models/data/entities/sales/store-contact/store-contact';
import { IStoreContactLookupModel } from 'app/models/data/entities/sales/store-contact/store-contact-lookup-model';
import { IStoreContactUpdateModel } from 'app/models/data/entities/sales/store-contact/store-contact-update-model';
import { IStoreContactsListViewModel } from 'app/models/data/entities/sales/store-contact/store-contacts-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IStoreContactPrimaryKey {
  customerID: number;
  contactID: number;
}

export interface IStoreContactUpdateItem extends IStoreContact {
  requestTarget: IStoreContactPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class StoreContactsService {
  constructor(protected apiClient: DataService) { }

  create(model: IStoreContact, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreContactLookupModel>;
  create(model: IStoreContact, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreContactLookupModel>>;
  create(model: IStoreContact, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreContactLookupModel>>;
  create(model: IStoreContact, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IStoreContact, IStoreContactLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IStoreContact>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IStoreContactLookupModel>>;
  createMany(model: Array<IStoreContact>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IStoreContactLookupModel>>>;
  createMany(model: Array<IStoreContact>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IStoreContactLookupModel>>>;
  createMany(model: Array<IStoreContact>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IStoreContact>, Array<IStoreContactLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(customerID: number, contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(customerID: number, contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(customerID: number, contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(customerID: number, contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts', {
      customerID,
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IStoreContactPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IStoreContactPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IStoreContactPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IStoreContactPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IStoreContactPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(customerID: number, contactID: number, model: IStoreContactUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreContactLookupModel>;
  update(customerID: number, contactID: number, model: IStoreContactUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreContactLookupModel>>;
  update(customerID: number, contactID: number, model: IStoreContactUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreContactLookupModel>>;
  update(customerID: number, contactID: number, model: IStoreContactUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts', {
      customerID,
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IStoreContactUpdateModel, IStoreContactLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IStoreContactUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IStoreContactLookupModel>>;
  updateMany(model: Array<IStoreContactUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IStoreContactLookupModel>>>;
  updateMany(model: Array<IStoreContactUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IStoreContactLookupModel>>>;
  updateMany(model: Array<IStoreContactUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IStoreContactUpdateItem>, Array<IStoreContactLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(customerID: number, contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreContactLookupModel>;
  get(customerID: number, contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreContactLookupModel>>;
  get(customerID: number, contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreContactLookupModel>>;
  get(customerID: number, contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts', {
      customerID,
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStoreContactLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByContact(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreContactsListViewModel>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreContactsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreContactsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts/GetStoreContactsByContact', {
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStoreContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreContactsListViewModel>;
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreContactsListViewModel>>;
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreContactsListViewModel>>;
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts/GetStoreContactsByContactType', {
      contactTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStoreContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByStore(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStoreContactsListViewModel>;
  getByStore(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStoreContactsListViewModel>>;
  getByStore(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStoreContactsListViewModel>>;
  getByStore(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StoreContacts/GetStoreContactsByStore', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStoreContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
