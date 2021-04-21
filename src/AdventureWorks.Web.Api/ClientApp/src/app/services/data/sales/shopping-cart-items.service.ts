import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IShoppingCartItem } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item';
import { IShoppingCartItemLookupModel } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item-lookup-model';
import { IShoppingCartItemUpdateModel } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item-update-model';
import { IShoppingCartItemsListViewModel } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-items-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IShoppingCartItemPrimaryKey {
  shoppingCartItemID: number;
}

export interface IShoppingCartItemUpdateItem extends IShoppingCartItem {
  requestTarget: IShoppingCartItemPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartItemsService {
  constructor(protected apiClient: DataService) {}

  create(model: IShoppingCartItem, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShoppingCartItemLookupModel>;
  create(model: IShoppingCartItem, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShoppingCartItemLookupModel>>;
  create(model: IShoppingCartItem, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShoppingCartItemLookupModel>>;
  create(model: IShoppingCartItem, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems', {});

    return this.apiClient.create<IShoppingCartItem, IShoppingCartItemLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IShoppingCartItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IShoppingCartItemLookupModel>>;
  createMany(model: Array<IShoppingCartItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IShoppingCartItemLookupModel>>>;
  createMany(model: Array<IShoppingCartItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IShoppingCartItemLookupModel>>>;
  createMany(model: Array<IShoppingCartItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems/createMany', {});

    return this.apiClient.create<Array<IShoppingCartItem>, Array<IShoppingCartItemLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(shoppingCartItemID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(shoppingCartItemID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(shoppingCartItemID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(shoppingCartItemID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems', {
      shoppingCartItemID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IShoppingCartItemPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IShoppingCartItemPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IShoppingCartItemPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IShoppingCartItemPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems/DeleteMany', {});

    return this.apiClient.post<Array<IShoppingCartItemPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(shoppingCartItemID: number, model: IShoppingCartItemUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShoppingCartItemLookupModel>;
  update(shoppingCartItemID: number, model: IShoppingCartItemUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShoppingCartItemLookupModel>>;
  update(shoppingCartItemID: number, model: IShoppingCartItemUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShoppingCartItemLookupModel>>;
  update(shoppingCartItemID: number, model: IShoppingCartItemUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems', {
      shoppingCartItemID,
    });

    return this.apiClient.update<IShoppingCartItemUpdateModel, IShoppingCartItemLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IShoppingCartItemUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IShoppingCartItemLookupModel>>;
  updateMany(model: Array<IShoppingCartItemUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IShoppingCartItemLookupModel>>>;
  updateMany(model: Array<IShoppingCartItemUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IShoppingCartItemLookupModel>>>;
  updateMany(model: Array<IShoppingCartItemUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems/UpdateMany', {});

    return this.apiClient.update<Array<IShoppingCartItemUpdateItem>, Array<IShoppingCartItemLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(shoppingCartItemID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShoppingCartItemLookupModel>;
  get(shoppingCartItemID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShoppingCartItemLookupModel>>;
  get(shoppingCartItemID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShoppingCartItemLookupModel>>;
  get(shoppingCartItemID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems', {
      shoppingCartItemID,
    });

    return this.apiClient.get<IShoppingCartItemLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IShoppingCartItemsListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IShoppingCartItemsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IShoppingCartItemsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ShoppingCartItems/GetShoppingCartItemsByProduct', {
      productID,
    });

    return this.apiClient.get<IShoppingCartItemsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
