import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IBillOfMaterials } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials';
import { IBillOfMaterialsLookupModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-lookup-model';
import { IBillOfMaterialsUpdateModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-update-model';
import { IBillOfMaterialsListViewModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IBillOfMaterialsPrimaryKey {
  billOfMaterialsID: number;
}

export interface IBillOfMaterialsUpdateItem extends IBillOfMaterials {
  requestTarget: IBillOfMaterialsPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class BillOfMaterialsService {
  constructor(protected apiClient: DataService) {}

  create(model: IBillOfMaterials, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IBillOfMaterialsLookupModel>;
  create(model: IBillOfMaterials, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IBillOfMaterialsLookupModel>>;
  create(model: IBillOfMaterials, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IBillOfMaterialsLookupModel>>;
  create(model: IBillOfMaterials, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IBillOfMaterials, IBillOfMaterialsLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IBillOfMaterials>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IBillOfMaterialsLookupModel>>;
  createMany(model: Array<IBillOfMaterials>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IBillOfMaterialsLookupModel>>>;
  createMany(model: Array<IBillOfMaterials>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IBillOfMaterialsLookupModel>>>;
  createMany(model: Array<IBillOfMaterials>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IBillOfMaterials>, Array<IBillOfMaterialsLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(billOfMaterialsID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(billOfMaterialsID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(billOfMaterialsID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(billOfMaterialsID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials', {
      billOfMaterialsID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IBillOfMaterialsPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IBillOfMaterialsPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IBillOfMaterialsPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IBillOfMaterialsPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IBillOfMaterialsPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(billOfMaterialsID: number, model: IBillOfMaterialsUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IBillOfMaterialsLookupModel>;
  update(billOfMaterialsID: number, model: IBillOfMaterialsUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IBillOfMaterialsLookupModel>>;
  update(billOfMaterialsID: number, model: IBillOfMaterialsUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IBillOfMaterialsLookupModel>>;
  update(billOfMaterialsID: number, model: IBillOfMaterialsUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials', {
      billOfMaterialsID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IBillOfMaterialsUpdateModel, IBillOfMaterialsLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IBillOfMaterialsUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IBillOfMaterialsLookupModel>>;
  updateMany(model: Array<IBillOfMaterialsUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IBillOfMaterialsLookupModel>>>;
  updateMany(model: Array<IBillOfMaterialsUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IBillOfMaterialsLookupModel>>>;
  updateMany(model: Array<IBillOfMaterialsUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IBillOfMaterialsUpdateItem>, Array<IBillOfMaterialsLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(billOfMaterialsID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IBillOfMaterialsLookupModel>;
  get(billOfMaterialsID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IBillOfMaterialsLookupModel>>;
  get(billOfMaterialsID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IBillOfMaterialsLookupModel>>;
  get(billOfMaterialsID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials', {
      billOfMaterialsID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IBillOfMaterialsLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByComponentProduct(componentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IBillOfMaterialsListViewModel>;
  getByComponentProduct(componentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IBillOfMaterialsListViewModel>>;
  getByComponentProduct(componentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IBillOfMaterialsListViewModel>>;
  getByComponentProduct(componentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials/GetBillOfMaterialsByComponentProduct', {
      componentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IBillOfMaterialsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByAssemblyProduct(productAssemblyID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IBillOfMaterialsListViewModel>;
  getByAssemblyProduct(productAssemblyID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IBillOfMaterialsListViewModel>>;
  getByAssemblyProduct(productAssemblyID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IBillOfMaterialsListViewModel>>;
  getByAssemblyProduct(productAssemblyID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials/GetBillOfMaterialsByAssemblyProduct', {
      productAssemblyID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IBillOfMaterialsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IBillOfMaterialsListViewModel>;
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IBillOfMaterialsListViewModel>>;
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IBillOfMaterialsListViewModel>>;
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('BillOfMaterials/GetBillOfMaterialsByUnitMeasure', {
      unitMeasureCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IBillOfMaterialsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
