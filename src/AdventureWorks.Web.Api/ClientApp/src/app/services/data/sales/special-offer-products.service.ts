import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISpecialOfferProduct } from 'app/models/data/entities/sales/special-offer-product/special-offer-product';
import { ISpecialOfferProductLookupModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-lookup-model';
import { ISpecialOfferProductUpdateModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-update-model';
import { ISpecialOfferProductsListViewModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-products-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface ISpecialOfferProductPrimaryKey {
  specialOfferID: number;
  productID: number;
}

export interface ISpecialOfferProductUpdateItem extends ISpecialOfferProduct {
  requestTarget: ISpecialOfferProductPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SpecialOfferProductsService {
  constructor(protected apiClient: DataService) {}

  create(model: ISpecialOfferProduct, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferProductLookupModel>;
  create(model: ISpecialOfferProduct, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferProductLookupModel>>;
  create(model: ISpecialOfferProduct, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferProductLookupModel>>;
  create(model: ISpecialOfferProduct, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts', {});

    return this.apiClient.create<ISpecialOfferProduct, ISpecialOfferProductLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISpecialOfferProduct>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISpecialOfferProductLookupModel>>;
  createMany(model: Array<ISpecialOfferProduct>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISpecialOfferProductLookupModel>>>;
  createMany(model: Array<ISpecialOfferProduct>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISpecialOfferProductLookupModel>>>;
  createMany(model: Array<ISpecialOfferProduct>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts/createMany', {});

    return this.apiClient.create<Array<ISpecialOfferProduct>, Array<ISpecialOfferProductLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(specialOfferID: number, productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(specialOfferID: number, productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(specialOfferID: number, productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(specialOfferID: number, productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts', {
      specialOfferID,
      productID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISpecialOfferProductPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISpecialOfferProductPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISpecialOfferProductPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISpecialOfferProductPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts/DeleteMany', {});

    return this.apiClient.post<Array<ISpecialOfferProductPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(specialOfferID: number, productID: number, model: ISpecialOfferProductUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferProductLookupModel>;
  update(specialOfferID: number, productID: number, model: ISpecialOfferProductUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferProductLookupModel>>;
  update(specialOfferID: number, productID: number, model: ISpecialOfferProductUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferProductLookupModel>>;
  update(specialOfferID: number, productID: number, model: ISpecialOfferProductUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts', {
      specialOfferID,
      productID,
    });

    return this.apiClient.update<ISpecialOfferProductUpdateModel, ISpecialOfferProductLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISpecialOfferProductUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISpecialOfferProductLookupModel>>;
  updateMany(model: Array<ISpecialOfferProductUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISpecialOfferProductLookupModel>>>;
  updateMany(model: Array<ISpecialOfferProductUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISpecialOfferProductLookupModel>>>;
  updateMany(model: Array<ISpecialOfferProductUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts/UpdateMany', {});

    return this.apiClient.update<Array<ISpecialOfferProductUpdateItem>, Array<ISpecialOfferProductLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(specialOfferID: number, productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferProductLookupModel>;
  get(specialOfferID: number, productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferProductLookupModel>>;
  get(specialOfferID: number, productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferProductLookupModel>>;
  get(specialOfferID: number, productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts', {
      specialOfferID,
      productID,
    });

    return this.apiClient.get<ISpecialOfferProductLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferProductsListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferProductsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferProductsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts/GetSpecialOfferProductsByProduct', {
      productID,
    });

    return this.apiClient.get<ISpecialOfferProductsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySpecialOffer(specialOfferID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISpecialOfferProductsListViewModel>;
  getBySpecialOffer(specialOfferID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISpecialOfferProductsListViewModel>>;
  getBySpecialOffer(specialOfferID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISpecialOfferProductsListViewModel>>;
  getBySpecialOffer(specialOfferID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SpecialOfferProducts/GetSpecialOfferProductsBySpecialOffer', {
      specialOfferID,
    });

    return this.apiClient.get<ISpecialOfferProductsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
