import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IShift } from 'app/models/data/entities/human-resources/shift/shift';
import { IShiftLookupModel } from 'app/models/data/entities/human-resources/shift/shift-lookup-model';
import { IShiftUpdateModel } from 'app/models/data/entities/human-resources/shift/shift-update-model';
import { IShiftsListViewModel } from 'app/models/data/entities/human-resources/shift/shifts-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface IShiftPrimaryKey {
  shiftID: number;
}

export interface IShiftUpdateItem extends IShift {
  requestTarget: IShiftPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ShiftsService {
  constructor(protected apiClient: DataService) { }

  create(model: IShift, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShiftLookupModel>;
  create(model: IShift, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShiftLookupModel>>;
  create(model: IShift, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShiftLookupModel>>;
  create(model: IShift, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Shifts', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IShift, IShiftLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IShift>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IShiftLookupModel>>;
  createMany(model: Array<IShift>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IShiftLookupModel>>>;
  createMany(model: Array<IShift>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IShiftLookupModel>>>;
  createMany(model: Array<IShift>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Shifts/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IShift>, Array<IShiftLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(shiftID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(shiftID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(shiftID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(shiftID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Shifts', {
      shiftID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IShiftPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IShiftPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IShiftPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IShiftPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Shifts/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IShiftPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(shiftID: number, model: IShiftUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShiftLookupModel>;
  update(shiftID: number, model: IShiftUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShiftLookupModel>>;
  update(shiftID: number, model: IShiftUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShiftLookupModel>>;
  update(shiftID: number, model: IShiftUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Shifts', {
      shiftID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IShiftUpdateModel, IShiftLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IShiftUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IShiftLookupModel>>;
  updateMany(model: Array<IShiftUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IShiftLookupModel>>>;
  updateMany(model: Array<IShiftUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IShiftLookupModel>>>;
  updateMany(model: Array<IShiftUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Shifts/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IShiftUpdateItem>, Array<IShiftLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(shiftID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShiftLookupModel>;
  get(shiftID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShiftLookupModel>>;
  get(shiftID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShiftLookupModel>>;
  get(shiftID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Shifts', {
      shiftID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IShiftLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShiftsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShiftsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShiftsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Shifts/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IShiftsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
