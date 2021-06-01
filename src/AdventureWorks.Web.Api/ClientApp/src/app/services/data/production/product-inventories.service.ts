import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductInventory } from 'app/models/data/entities/production/product-inventory/product-inventory';
import { IProductInventoryLookupModel } from 'app/models/data/entities/production/product-inventory/product-inventory-lookup-model';
import { IProductInventoryUpdateModel } from 'app/models/data/entities/production/product-inventory/product-inventory-update-model';
import { IProductInventoriesListViewModel } from 'app/models/data/entities/production/product-inventory/product-inventories-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductInventoryPrimaryKey {
  productID: number;
  locationID: number;
}

export interface IProductInventoryUpdateItem extends IProductInventory {
  requestTarget: IProductInventoryPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductInventoriesService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductInventory, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductInventoryLookupModel>;
  create(model: IProductInventory, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductInventoryLookupModel>>;
  create(model: IProductInventory, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductInventoryLookupModel>>;
  create(model: IProductInventory, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductInventory, IProductInventoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductInventory>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductInventoryLookupModel>>;
  createMany(model: Array<IProductInventory>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductInventoryLookupModel>>>;
  createMany(model: Array<IProductInventory>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductInventoryLookupModel>>>;
  createMany(model: Array<IProductInventory>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductInventory>, Array<IProductInventoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, locationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, locationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, locationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, locationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories', {
      productID,
      locationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductInventoryPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductInventoryPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductInventoryPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductInventoryPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductInventoryPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, locationID: number, model: IProductInventoryUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductInventoryLookupModel>;
  update(productID: number, locationID: number, model: IProductInventoryUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductInventoryLookupModel>>;
  update(productID: number, locationID: number, model: IProductInventoryUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductInventoryLookupModel>>;
  update(productID: number, locationID: number, model: IProductInventoryUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories', {
      productID,
      locationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductInventoryUpdateModel, IProductInventoryLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductInventoryUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductInventoryLookupModel>>;
  updateMany(model: Array<IProductInventoryUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductInventoryLookupModel>>>;
  updateMany(model: Array<IProductInventoryUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductInventoryLookupModel>>>;
  updateMany(model: Array<IProductInventoryUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductInventoryUpdateItem>, Array<IProductInventoryLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, locationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductInventoryLookupModel>;
  get(productID: number, locationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductInventoryLookupModel>>;
  get(productID: number, locationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductInventoryLookupModel>>;
  get(productID: number, locationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories', {
      productID,
      locationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductInventoryLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByLocation(locationID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductInventoriesListViewModel>;
  getByLocation(locationID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductInventoriesListViewModel>>;
  getByLocation(locationID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductInventoriesListViewModel>>;
  getByLocation(locationID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories/GetProductInventoriesByLocation', {
      locationID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductInventoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductInventoriesListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductInventoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductInventoriesListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductInventories/GetProductInventoriesByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductInventoriesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
