import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IUnitMeasure } from 'app/models/data/entities/production/unit-measure/unit-measure';
import { IUnitMeasureLookupModel } from 'app/models/data/entities/production/unit-measure/unit-measure-lookup-model';
import { IUnitMeasureUpdateModel } from 'app/models/data/entities/production/unit-measure/unit-measure-update-model';
import { IUnitMeasuresListViewModel } from 'app/models/data/entities/production/unit-measure/unit-measures-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IUnitMeasurePrimaryKey {
  unitMeasureCode: string;
}

export interface IUnitMeasureUpdateItem extends IUnitMeasure {
  requestTarget: IUnitMeasurePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class UnitMeasuresService {
  constructor(protected apiClient: DataService) { }

  create(model: IUnitMeasure, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IUnitMeasureLookupModel>;
  create(model: IUnitMeasure, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IUnitMeasureLookupModel>>;
  create(model: IUnitMeasure, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IUnitMeasureLookupModel>>;
  create(model: IUnitMeasure, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IUnitMeasure, IUnitMeasureLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IUnitMeasure>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IUnitMeasureLookupModel>>;
  createMany(model: Array<IUnitMeasure>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IUnitMeasureLookupModel>>>;
  createMany(model: Array<IUnitMeasure>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IUnitMeasureLookupModel>>>;
  createMany(model: Array<IUnitMeasure>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IUnitMeasure>, Array<IUnitMeasureLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(unitMeasureCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(unitMeasureCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(unitMeasureCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(unitMeasureCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures', {
      unitMeasureCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IUnitMeasurePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IUnitMeasurePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IUnitMeasurePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IUnitMeasurePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IUnitMeasurePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(unitMeasureCode: string, model: IUnitMeasureUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IUnitMeasureLookupModel>;
  update(unitMeasureCode: string, model: IUnitMeasureUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IUnitMeasureLookupModel>>;
  update(unitMeasureCode: string, model: IUnitMeasureUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IUnitMeasureLookupModel>>;
  update(unitMeasureCode: string, model: IUnitMeasureUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures', {
      unitMeasureCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IUnitMeasureUpdateModel, IUnitMeasureLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IUnitMeasureUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IUnitMeasureLookupModel>>;
  updateMany(model: Array<IUnitMeasureUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IUnitMeasureLookupModel>>>;
  updateMany(model: Array<IUnitMeasureUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IUnitMeasureLookupModel>>>;
  updateMany(model: Array<IUnitMeasureUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IUnitMeasureUpdateItem>, Array<IUnitMeasureLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(unitMeasureCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IUnitMeasureLookupModel>;
  get(unitMeasureCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IUnitMeasureLookupModel>>;
  get(unitMeasureCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IUnitMeasureLookupModel>>;
  get(unitMeasureCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures', {
      unitMeasureCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IUnitMeasureLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IUnitMeasuresListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IUnitMeasuresListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IUnitMeasuresListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('UnitMeasures/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IUnitMeasuresListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
