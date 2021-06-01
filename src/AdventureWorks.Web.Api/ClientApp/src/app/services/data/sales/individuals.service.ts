import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IIndividual } from 'app/models/data/entities/sales/individual/individual';
import { IIndividualLookupModel } from 'app/models/data/entities/sales/individual/individual-lookup-model';
import { IIndividualUpdateModel } from 'app/models/data/entities/sales/individual/individual-update-model';
import { IIndividualsListViewModel } from 'app/models/data/entities/sales/individual/individuals-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IIndividualPrimaryKey {
  customerID: number;
}

export interface IIndividualUpdateItem extends IIndividual {
  requestTarget: IIndividualPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class IndividualsService {
  constructor(protected apiClient: DataService) {}

  create(model: IIndividual, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIndividualLookupModel>;
  create(model: IIndividual, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIndividualLookupModel>>;
  create(model: IIndividual, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIndividualLookupModel>>;
  create(model: IIndividual, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Individuals', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IIndividual, IIndividualLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IIndividual>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IIndividualLookupModel>>;
  createMany(model: Array<IIndividual>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IIndividualLookupModel>>>;
  createMany(model: Array<IIndividual>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IIndividualLookupModel>>>;
  createMany(model: Array<IIndividual>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Individuals/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IIndividual>, Array<IIndividualLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Individuals', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IIndividualPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IIndividualPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IIndividualPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IIndividualPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Individuals/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IIndividualPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(customerID: number, model: IIndividualUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIndividualLookupModel>;
  update(customerID: number, model: IIndividualUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIndividualLookupModel>>;
  update(customerID: number, model: IIndividualUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIndividualLookupModel>>;
  update(customerID: number, model: IIndividualUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Individuals', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IIndividualUpdateModel, IIndividualLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IIndividualUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IIndividualLookupModel>>;
  updateMany(model: Array<IIndividualUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IIndividualLookupModel>>>;
  updateMany(model: Array<IIndividualUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IIndividualLookupModel>>>;
  updateMany(model: Array<IIndividualUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Individuals/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IIndividualUpdateItem>, Array<IIndividualLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIndividualLookupModel>;
  get(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIndividualLookupModel>>;
  get(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIndividualLookupModel>>;
  get(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Individuals', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IIndividualLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByContact(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIndividualsListViewModel>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIndividualsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIndividualsListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Individuals/GetIndividualsByContact', {
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IIndividualsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IIndividualsListViewModel>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IIndividualsListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IIndividualsListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Individuals/GetIndividualsByCustomer', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IIndividualsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
