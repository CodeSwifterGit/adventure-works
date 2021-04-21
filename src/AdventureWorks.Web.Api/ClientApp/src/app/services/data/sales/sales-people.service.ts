import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesPerson } from 'app/models/data/entities/sales/sales-person/sales-person';
import { ISalesPersonLookupModel } from 'app/models/data/entities/sales/sales-person/sales-person-lookup-model';
import { ISalesPersonUpdateModel } from 'app/models/data/entities/sales/sales-person/sales-person-update-model';
import { ISalesPeopleListViewModel } from 'app/models/data/entities/sales/sales-person/sales-people-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ISalesPersonPrimaryKey {
  salesPersonID: number;
}

export interface ISalesPersonUpdateItem extends ISalesPerson {
  requestTarget: ISalesPersonPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesPeopleService {
  constructor(protected apiClient: DataService) {}

  create(model: ISalesPerson, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonLookupModel>;
  create(model: ISalesPerson, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonLookupModel>>;
  create(model: ISalesPerson, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonLookupModel>>;
  create(model: ISalesPerson, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople', {});

    return this.apiClient.create<ISalesPerson, ISalesPersonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesPerson>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesPersonLookupModel>>;
  createMany(model: Array<ISalesPerson>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesPersonLookupModel>>>;
  createMany(model: Array<ISalesPerson>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesPersonLookupModel>>>;
  createMany(model: Array<ISalesPerson>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople/createMany', {});

    return this.apiClient.create<Array<ISalesPerson>, Array<ISalesPersonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesPersonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesPersonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesPersonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesPersonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople', {
      salesPersonID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesPersonPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesPersonPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesPersonPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesPersonPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople/DeleteMany', {});

    return this.apiClient.post<Array<ISalesPersonPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesPersonID: number, model: ISalesPersonUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonLookupModel>;
  update(salesPersonID: number, model: ISalesPersonUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonLookupModel>>;
  update(salesPersonID: number, model: ISalesPersonUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonLookupModel>>;
  update(salesPersonID: number, model: ISalesPersonUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople', {
      salesPersonID,
    });

    return this.apiClient.update<ISalesPersonUpdateModel, ISalesPersonLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesPersonUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesPersonLookupModel>>;
  updateMany(model: Array<ISalesPersonUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesPersonLookupModel>>>;
  updateMany(model: Array<ISalesPersonUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesPersonLookupModel>>>;
  updateMany(model: Array<ISalesPersonUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople/UpdateMany', {});

    return this.apiClient.update<Array<ISalesPersonUpdateItem>, Array<ISalesPersonLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesPersonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPersonLookupModel>;
  get(salesPersonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPersonLookupModel>>;
  get(salesPersonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPersonLookupModel>>;
  get(salesPersonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople', {
      salesPersonID,
    });

    return this.apiClient.get<ISalesPersonLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByEmployee(salesPersonID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPeopleListViewModel>;
  getByEmployee(salesPersonID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPeopleListViewModel>>;
  getByEmployee(salesPersonID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPeopleListViewModel>>;
  getByEmployee(salesPersonID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople/GetSalesPeopleByEmployee', {
      salesPersonID,
    });

    return this.apiClient.get<ISalesPeopleListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesPeopleListViewModel>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesPeopleListViewModel>>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesPeopleListViewModel>>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesPeople/GetSalesPeopleBySalesTerritory', {
      territoryID,
    });

    return this.apiClient.get<ISalesPeopleListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
