import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IContactCreditCard } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card';
import { IContactCreditCardLookupModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-lookup-model';
import { IContactCreditCardUpdateModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-card-update-model';
import { IContactCreditCardsListViewModel } from 'app/models/data/entities/sales/contact-credit-card/contact-credit-cards-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IContactCreditCardPrimaryKey {
  contactID: number;
  creditCardID: number;
}

export interface IContactCreditCardUpdateItem extends IContactCreditCard {
  requestTarget: IContactCreditCardPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ContactCreditCardsService {
  constructor(protected apiClient: DataService) {}

  create(model: IContactCreditCard, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactCreditCardLookupModel>;
  create(model: IContactCreditCard, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactCreditCardLookupModel>>;
  create(model: IContactCreditCard, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactCreditCardLookupModel>>;
  create(model: IContactCreditCard, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards', {});

    return this.apiClient.create<IContactCreditCard, IContactCreditCardLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IContactCreditCard>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IContactCreditCardLookupModel>>;
  createMany(model: Array<IContactCreditCard>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IContactCreditCardLookupModel>>>;
  createMany(model: Array<IContactCreditCard>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IContactCreditCardLookupModel>>>;
  createMany(model: Array<IContactCreditCard>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards/createMany', {});

    return this.apiClient.create<Array<IContactCreditCard>, Array<IContactCreditCardLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(contactID: number, creditCardID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(contactID: number, creditCardID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(contactID: number, creditCardID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(contactID: number, creditCardID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards', {
      contactID,
      creditCardID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IContactCreditCardPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IContactCreditCardPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IContactCreditCardPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IContactCreditCardPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards/DeleteMany', {});

    return this.apiClient.post<Array<IContactCreditCardPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(contactID: number, creditCardID: number, model: IContactCreditCardUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactCreditCardLookupModel>;
  update(contactID: number, creditCardID: number, model: IContactCreditCardUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactCreditCardLookupModel>>;
  update(contactID: number, creditCardID: number, model: IContactCreditCardUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactCreditCardLookupModel>>;
  update(contactID: number, creditCardID: number, model: IContactCreditCardUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards', {
      contactID,
      creditCardID,
    });

    return this.apiClient.update<IContactCreditCardUpdateModel, IContactCreditCardLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IContactCreditCardUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IContactCreditCardLookupModel>>;
  updateMany(model: Array<IContactCreditCardUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IContactCreditCardLookupModel>>>;
  updateMany(model: Array<IContactCreditCardUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IContactCreditCardLookupModel>>>;
  updateMany(model: Array<IContactCreditCardUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards/UpdateMany', {});

    return this.apiClient.update<Array<IContactCreditCardUpdateItem>, Array<IContactCreditCardLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(contactID: number, creditCardID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactCreditCardLookupModel>;
  get(contactID: number, creditCardID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactCreditCardLookupModel>>;
  get(contactID: number, creditCardID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactCreditCardLookupModel>>;
  get(contactID: number, creditCardID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards', {
      contactID,
      creditCardID,
    });

    return this.apiClient.get<IContactCreditCardLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByContact(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactCreditCardsListViewModel>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactCreditCardsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactCreditCardsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards/GetContactCreditCardsByContact', {
      contactID,
    });

    return this.apiClient.get<IContactCreditCardsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCreditCard(creditCardID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IContactCreditCardsListViewModel>;
  getByCreditCard(creditCardID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IContactCreditCardsListViewModel>>;
  getByCreditCard(creditCardID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IContactCreditCardsListViewModel>>;
  getByCreditCard(creditCardID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ContactCreditCards/GetContactCreditCardsByCreditCard', {
      creditCardID,
    });

    return this.apiClient.get<IContactCreditCardsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
