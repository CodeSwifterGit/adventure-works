import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductReview } from 'app/models/data/entities/production/product-review/product-review';
import { IProductReviewLookupModel } from 'app/models/data/entities/production/product-review/product-review-lookup-model';
import { IProductReviewUpdateModel } from 'app/models/data/entities/production/product-review/product-review-update-model';
import { IProductReviewsListViewModel } from 'app/models/data/entities/production/product-review/product-reviews-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductReviewPrimaryKey {
  productReviewID: number;
}

export interface IProductReviewUpdateItem extends IProductReview {
  requestTarget: IProductReviewPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductReviewsService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductReview, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductReviewLookupModel>;
  create(model: IProductReview, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductReviewLookupModel>>;
  create(model: IProductReview, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductReviewLookupModel>>;
  create(model: IProductReview, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IProductReview, IProductReviewLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductReview>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductReviewLookupModel>>;
  createMany(model: Array<IProductReview>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductReviewLookupModel>>>;
  createMany(model: Array<IProductReview>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductReviewLookupModel>>>;
  createMany(model: Array<IProductReview>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IProductReview>, Array<IProductReviewLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productReviewID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productReviewID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productReviewID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productReviewID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews', {
      productReviewID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductReviewPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductReviewPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductReviewPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductReviewPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IProductReviewPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productReviewID: number, model: IProductReviewUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductReviewLookupModel>;
  update(productReviewID: number, model: IProductReviewUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductReviewLookupModel>>;
  update(productReviewID: number, model: IProductReviewUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductReviewLookupModel>>;
  update(productReviewID: number, model: IProductReviewUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews', {
      productReviewID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IProductReviewUpdateModel, IProductReviewLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductReviewUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductReviewLookupModel>>;
  updateMany(model: Array<IProductReviewUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductReviewLookupModel>>>;
  updateMany(model: Array<IProductReviewUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductReviewLookupModel>>>;
  updateMany(model: Array<IProductReviewUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IProductReviewUpdateItem>, Array<IProductReviewLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productReviewID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductReviewLookupModel>;
  get(productReviewID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductReviewLookupModel>>;
  get(productReviewID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductReviewLookupModel>>;
  get(productReviewID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews', {
      productReviewID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductReviewLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductReviewsListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductReviewsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductReviewsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductReviews/GetProductReviewsByProduct', {
      productID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IProductReviewsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
