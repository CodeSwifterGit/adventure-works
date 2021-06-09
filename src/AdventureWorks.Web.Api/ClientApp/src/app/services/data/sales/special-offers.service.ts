import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISpecialOffer } from 'app/models/data/entities/sales/special-offer/special-offer';
import { ISpecialOfferLookupModel } from 'app/models/data/entities/sales/special-offer/special-offer-lookup-model';
import { ISpecialOfferUpdateModel } from 'app/models/data/entities/sales/special-offer/special-offer-update-model';
import { ISpecialOffersListViewModel } from 'app/models/data/entities/sales/special-offer/special-offers-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface ISpecialOfferPrimaryKey {
  specialOfferID: number;
}

export interface ISpecialOfferUpdateItem extends ISpecialOffer {
  requestTarget: ISpecialOfferPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SpecialOffersService {
  constructor(protected apiClient: DataService) { }

  create(model: ISpecialOffer, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferLookupModel>;
  create(model: ISpecialOffer, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferLookupModel>>;
  create(model: ISpecialOffer, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferLookupModel>>;
  create(model: ISpecialOffer, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISpecialOffer, ISpecialOfferLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISpecialOffer>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISpecialOfferLookupModel>>;
  createMany(model: Array<ISpecialOffer>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISpecialOfferLookupModel>>>;
  createMany(model: Array<ISpecialOffer>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISpecialOfferLookupModel>>>;
  createMany(model: Array<ISpecialOffer>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISpecialOffer>, Array<ISpecialOfferLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(specialOfferID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(specialOfferID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(specialOfferID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(specialOfferID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers', {
      specialOfferID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISpecialOfferPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISpecialOfferPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISpecialOfferPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISpecialOfferPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISpecialOfferPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(specialOfferID: number, model: ISpecialOfferUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferLookupModel>;
  update(specialOfferID: number, model: ISpecialOfferUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferLookupModel>>;
  update(specialOfferID: number, model: ISpecialOfferUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferLookupModel>>;
  update(specialOfferID: number, model: ISpecialOfferUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers', {
      specialOfferID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISpecialOfferUpdateModel, ISpecialOfferLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISpecialOfferUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISpecialOfferLookupModel>>;
  updateMany(model: Array<ISpecialOfferUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISpecialOfferLookupModel>>>;
  updateMany(model: Array<ISpecialOfferUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISpecialOfferLookupModel>>>;
  updateMany(model: Array<ISpecialOfferUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISpecialOfferUpdateItem>, Array<ISpecialOfferLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(specialOfferID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferLookupModel>;
  get(specialOfferID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferLookupModel>>;
  get(specialOfferID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferLookupModel>>;
  get(specialOfferID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers', {
      specialOfferID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISpecialOfferLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOffersListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOffersListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOffersListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOffers/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<ISpecialOffersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
