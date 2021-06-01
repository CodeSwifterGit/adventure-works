import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductVendor } from 'app/models/data/entities/purchasing/product-vendor/product-vendor';
import { IProductVendorLookupModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-lookup-model';
import { IProductVendorUpdateModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-update-model';
import { IProductVendorsListViewModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendors-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductVendorPrimaryKey {
  productID: number;
  vendorID: number;
}

export interface IProductVendorUpdateItem extends IProductVendor {
  requestTarget: IProductVendorPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductVendorsService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductVendor, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductVendorLookupModel>;
  create(model: IProductVendor, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductVendorLookupModel>>;
  create(model: IProductVendor, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductVendorLookupModel>>;
  create(model: IProductVendor, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductVendor, IProductVendorLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductVendor>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductVendorLookupModel>>;
  createMany(model: Array<IProductVendor>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductVendorLookupModel>>>;
  createMany(model: Array<IProductVendor>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductVendorLookupModel>>>;
  createMany(model: Array<IProductVendor>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductVendor>, Array<IProductVendorLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors', {
      productID,
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductVendorPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductVendorPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductVendorPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductVendorPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductVendorPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, vendorID: number, model: IProductVendorUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductVendorLookupModel>;
  update(productID: number, vendorID: number, model: IProductVendorUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductVendorLookupModel>>;
  update(productID: number, vendorID: number, model: IProductVendorUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductVendorLookupModel>>;
  update(productID: number, vendorID: number, model: IProductVendorUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors', {
      productID,
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductVendorUpdateModel, IProductVendorLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductVendorUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductVendorLookupModel>>;
  updateMany(model: Array<IProductVendorUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductVendorLookupModel>>>;
  updateMany(model: Array<IProductVendorUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductVendorLookupModel>>>;
  updateMany(model: Array<IProductVendorUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductVendorUpdateItem>, Array<IProductVendorLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductVendorLookupModel>;
  get(productID: number, vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductVendorLookupModel>>;
  get(productID: number, vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductVendorLookupModel>>;
  get(productID: number, vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors', {
      productID,
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductVendorLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductVendorsListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductVendorsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductVendorsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors/GetProductVendorsByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductVendorsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductVendorsListViewModel>;
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductVendorsListViewModel>>;
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductVendorsListViewModel>>;
  getByUnitMeasure(unitMeasureCode: string, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors/GetProductVendorsByUnitMeasure', {
      unitMeasureCode,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductVendorsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductVendorsListViewModel>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductVendorsListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductVendorsListViewModel>>;
  getByVendor(vendorID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductVendors/GetProductVendorsByVendor', {
      vendorID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductVendorsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
