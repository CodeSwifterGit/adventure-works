import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IVendorContact } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact';
import { IVendorContactLookupModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-lookup-model';
import { IVendorContactUpdateModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-update-model';
import { IVendorContactsListViewModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contacts-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IVendorContactPrimaryKey {
  vendorID: number;
  contactID: number;
}

export interface IVendorContactUpdateItem extends IVendorContact {
  requestTarget: IVendorContactPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class VendorContactsService {
  constructor(protected apiClient: DataService) { }

  create(model: IVendorContact, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorContactLookupModel>;
  create(model: IVendorContact, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorContactLookupModel>>;
  create(model: IVendorContact, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorContactLookupModel>>;
  create(model: IVendorContact, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IVendorContact, IVendorContactLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IVendorContact>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IVendorContactLookupModel>>;
  createMany(model: Array<IVendorContact>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IVendorContactLookupModel>>>;
  createMany(model: Array<IVendorContact>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IVendorContactLookupModel>>>;
  createMany(model: Array<IVendorContact>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IVendorContact>, Array<IVendorContactLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(vendorID: number, contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(vendorID: number, contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(vendorID: number, contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(vendorID: number, contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts', {
      vendorID,
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IVendorContactPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IVendorContactPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IVendorContactPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IVendorContactPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IVendorContactPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(vendorID: number, contactID: number, model: IVendorContactUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorContactLookupModel>;
  update(vendorID: number, contactID: number, model: IVendorContactUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorContactLookupModel>>;
  update(vendorID: number, contactID: number, model: IVendorContactUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorContactLookupModel>>;
  update(vendorID: number, contactID: number, model: IVendorContactUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts', {
      vendorID,
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IVendorContactUpdateModel, IVendorContactLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IVendorContactUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IVendorContactLookupModel>>;
  updateMany(model: Array<IVendorContactUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IVendorContactLookupModel>>>;
  updateMany(model: Array<IVendorContactUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IVendorContactLookupModel>>>;
  updateMany(model: Array<IVendorContactUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IVendorContactUpdateItem>, Array<IVendorContactLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(vendorID: number, contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorContactLookupModel>;
  get(vendorID: number, contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorContactLookupModel>>;
  get(vendorID: number, contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorContactLookupModel>>;
  get(vendorID: number, contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts', {
      vendorID,
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorContactLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByContact(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorContactsListViewModel>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorContactsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorContactsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts/GetVendorContactsByContact', {
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorContactsListViewModel>;
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorContactsListViewModel>>;
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorContactsListViewModel>>;
  getByContactType(contactTypeID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts/GetVendorContactsByContactType', {
      contactTypeID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IVendorContactsListViewModel>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IVendorContactsListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IVendorContactsListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('VendorContacts/GetVendorContactsByVendor', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IVendorContactsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
