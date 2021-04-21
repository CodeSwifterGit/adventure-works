import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductModelIllustration } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration';
import { IProductModelIllustrationLookupModel } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-lookup-model';
import { IProductModelIllustrationUpdateModel } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-update-model';
import { IProductModelIllustrationsListViewModel } from 'app/models/data/entities/production/product-model-illustration/product-model-illustrations-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductModelIllustrationPrimaryKey {
  productModelID: number;
  illustrationID: number;
}

export interface IProductModelIllustrationUpdateItem extends IProductModelIllustration {
  requestTarget: IProductModelIllustrationPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductModelIllustrationsService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductModelIllustration, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelIllustrationLookupModel>;
  create(model: IProductModelIllustration, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelIllustrationLookupModel>>;
  create(model: IProductModelIllustration, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelIllustrationLookupModel>>;
  create(model: IProductModelIllustration, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations', {});

    return this.apiClient.create<IProductModelIllustration, IProductModelIllustrationLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductModelIllustration>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductModelIllustrationLookupModel>>;
  createMany(model: Array<IProductModelIllustration>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductModelIllustrationLookupModel>>>;
  createMany(model: Array<IProductModelIllustration>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductModelIllustrationLookupModel>>>;
  createMany(model: Array<IProductModelIllustration>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations/createMany', {});

    return this.apiClient.create<Array<IProductModelIllustration>, Array<IProductModelIllustrationLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productModelID: number, illustrationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productModelID: number, illustrationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productModelID: number, illustrationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productModelID: number, illustrationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations', {
      productModelID,
      illustrationID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductModelIllustrationPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductModelIllustrationPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductModelIllustrationPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductModelIllustrationPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations/DeleteMany', {});

    return this.apiClient.post<Array<IProductModelIllustrationPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productModelID: number, illustrationID: number, model: IProductModelIllustrationUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelIllustrationLookupModel>;
  update(productModelID: number, illustrationID: number, model: IProductModelIllustrationUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelIllustrationLookupModel>>;
  update(productModelID: number, illustrationID: number, model: IProductModelIllustrationUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelIllustrationLookupModel>>;
  update(productModelID: number, illustrationID: number, model: IProductModelIllustrationUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations', {
      productModelID,
      illustrationID,
    });

    return this.apiClient.update<IProductModelIllustrationUpdateModel, IProductModelIllustrationLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductModelIllustrationUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductModelIllustrationLookupModel>>;
  updateMany(model: Array<IProductModelIllustrationUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductModelIllustrationLookupModel>>>;
  updateMany(model: Array<IProductModelIllustrationUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductModelIllustrationLookupModel>>>;
  updateMany(model: Array<IProductModelIllustrationUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations/UpdateMany', {});

    return this.apiClient.update<Array<IProductModelIllustrationUpdateItem>, Array<IProductModelIllustrationLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productModelID: number, illustrationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelIllustrationLookupModel>;
  get(productModelID: number, illustrationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelIllustrationLookupModel>>;
  get(productModelID: number, illustrationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelIllustrationLookupModel>>;
  get(productModelID: number, illustrationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations', {
      productModelID,
      illustrationID,
    });

    return this.apiClient.get<IProductModelIllustrationLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByIllustration(illustrationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelIllustrationsListViewModel>;
  getByIllustration(illustrationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelIllustrationsListViewModel>>;
  getByIllustration(illustrationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelIllustrationsListViewModel>>;
  getByIllustration(illustrationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations/GetProductModelIllustrationsByIllustration', {
      illustrationID,
    });

    return this.apiClient.get<IProductModelIllustrationsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProductModel(productModelID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductModelIllustrationsListViewModel>;
  getByProductModel(productModelID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductModelIllustrationsListViewModel>>;
  getByProductModel(productModelID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductModelIllustrationsListViewModel>>;
  getByProductModel(productModelID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductModelIllustrations/GetProductModelIllustrationsByProductModel', {
      productModelID,
    });

    return this.apiClient.get<IProductModelIllustrationsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
