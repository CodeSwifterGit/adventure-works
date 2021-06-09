import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ICreditCard } from 'app/models/data/entities/sales/credit-card/credit-card';
import { ICreditCardLookupModel } from 'app/models/data/entities/sales/credit-card/credit-card-lookup-model';
import { ICreditCardUpdateModel } from 'app/models/data/entities/sales/credit-card/credit-card-update-model';
import { ICreditCardsListViewModel } from 'app/models/data/entities/sales/credit-card/credit-cards-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface ICreditCardPrimaryKey {
  creditCardID: number;
}

export interface ICreditCardUpdateItem extends ICreditCard {
  requestTarget: ICreditCardPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class CreditCardsService {
  constructor(protected apiClient: DataService) { }

  create(model: ICreditCard, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICreditCardLookupModel>;
  create(model: ICreditCard, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICreditCardLookupModel>>;
  create(model: ICreditCard, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICreditCardLookupModel>>;
  create(model: ICreditCard, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CreditCards', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ICreditCard, ICreditCardLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ICreditCard>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICreditCardLookupModel>>;
  createMany(model: Array<ICreditCard>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICreditCardLookupModel>>>;
  createMany(model: Array<ICreditCard>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICreditCardLookupModel>>>;
  createMany(model: Array<ICreditCard>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CreditCards/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ICreditCard>, Array<ICreditCardLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(creditCardID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(creditCardID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(creditCardID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(creditCardID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CreditCards', {
      creditCardID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ICreditCardPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ICreditCardPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ICreditCardPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ICreditCardPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CreditCards/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ICreditCardPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(creditCardID: number, model: ICreditCardUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICreditCardLookupModel>;
  update(creditCardID: number, model: ICreditCardUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICreditCardLookupModel>>;
  update(creditCardID: number, model: ICreditCardUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICreditCardLookupModel>>;
  update(creditCardID: number, model: ICreditCardUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CreditCards', {
      creditCardID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ICreditCardUpdateModel, ICreditCardLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ICreditCardUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ICreditCardLookupModel>>;
  updateMany(model: Array<ICreditCardUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ICreditCardLookupModel>>>;
  updateMany(model: Array<ICreditCardUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ICreditCardLookupModel>>>;
  updateMany(model: Array<ICreditCardUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('CreditCards/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ICreditCardUpdateItem>, Array<ICreditCardLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(creditCardID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICreditCardLookupModel>;
  get(creditCardID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICreditCardLookupModel>>;
  get(creditCardID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICreditCardLookupModel>>;
  get(creditCardID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CreditCards', {
      creditCardID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ICreditCardLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ICreditCardsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ICreditCardsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ICreditCardsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('CreditCards/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<ICreditCardsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
