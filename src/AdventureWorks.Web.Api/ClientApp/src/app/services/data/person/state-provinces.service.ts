import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IStateProvince } from 'app/models/data/entities/person/state-province/state-province';
import { IStateProvinceLookupModel } from 'app/models/data/entities/person/state-province/state-province-lookup-model';
import { IStateProvinceUpdateModel } from 'app/models/data/entities/person/state-province/state-province-update-model';
import { IStateProvincesListViewModel } from 'app/models/data/entities/person/state-province/state-provinces-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IStateProvincePrimaryKey {
  stateProvinceID: number;
}

export interface IStateProvinceUpdateItem extends IStateProvince {
  requestTarget: IStateProvincePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class StateProvincesService {
  constructor(protected apiClient: DataService) { }

  create(model: IStateProvince, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStateProvinceLookupModel>;
  create(model: IStateProvince, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStateProvinceLookupModel>>;
  create(model: IStateProvince, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStateProvinceLookupModel>>;
  create(model: IStateProvince, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IStateProvince, IStateProvinceLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IStateProvince>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IStateProvinceLookupModel>>;
  createMany(model: Array<IStateProvince>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IStateProvinceLookupModel>>>;
  createMany(model: Array<IStateProvince>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IStateProvinceLookupModel>>>;
  createMany(model: Array<IStateProvince>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IStateProvince>, Array<IStateProvinceLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(stateProvinceID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(stateProvinceID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(stateProvinceID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(stateProvinceID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces', {
      stateProvinceID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IStateProvincePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IStateProvincePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IStateProvincePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IStateProvincePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IStateProvincePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(stateProvinceID: number, model: IStateProvinceUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStateProvinceLookupModel>;
  update(stateProvinceID: number, model: IStateProvinceUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStateProvinceLookupModel>>;
  update(stateProvinceID: number, model: IStateProvinceUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStateProvinceLookupModel>>;
  update(stateProvinceID: number, model: IStateProvinceUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces', {
      stateProvinceID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IStateProvinceUpdateModel, IStateProvinceLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IStateProvinceUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IStateProvinceLookupModel>>;
  updateMany(model: Array<IStateProvinceUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IStateProvinceLookupModel>>>;
  updateMany(model: Array<IStateProvinceUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IStateProvinceLookupModel>>>;
  updateMany(model: Array<IStateProvinceUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IStateProvinceUpdateItem>, Array<IStateProvinceLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(stateProvinceID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStateProvinceLookupModel>;
  get(stateProvinceID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStateProvinceLookupModel>>;
  get(stateProvinceID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStateProvinceLookupModel>>;
  get(stateProvinceID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces', {
      stateProvinceID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStateProvinceLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStateProvincesListViewModel>;
  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStateProvincesListViewModel>>;
  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStateProvincesListViewModel>>;
  getByCountryRegion(countryRegionCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces/GetStateProvincesByCountryRegion', {
      countryRegionCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStateProvincesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IStateProvincesListViewModel>;
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IStateProvincesListViewModel>>;
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IStateProvincesListViewModel>>;
  getBySalesTerritory(territoryID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('StateProvinces/GetStateProvincesBySalesTerritory', {
      territoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IStateProvincesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
