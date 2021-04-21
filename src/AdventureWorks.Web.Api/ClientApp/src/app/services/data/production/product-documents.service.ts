import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IProductDocument } from 'app/models/data/entities/production/product-document/product-document';
import { IProductDocumentLookupModel } from 'app/models/data/entities/production/product-document/product-document-lookup-model';
import { IProductDocumentUpdateModel } from 'app/models/data/entities/production/product-document/product-document-update-model';
import { IProductDocumentsListViewModel } from 'app/models/data/entities/production/product-document/product-documents-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IProductDocumentPrimaryKey {
  productID: number;
  documentID: number;
}

export interface IProductDocumentUpdateItem extends IProductDocument {
  requestTarget: IProductDocumentPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class ProductDocumentsService {
  constructor(protected apiClient: DataService) {}

  create(model: IProductDocument, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDocumentLookupModel>;
  create(model: IProductDocument, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDocumentLookupModel>>;
  create(model: IProductDocument, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDocumentLookupModel>>;
  create(model: IProductDocument, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments', {});

    return this.apiClient.create<IProductDocument, IProductDocumentLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IProductDocument>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductDocumentLookupModel>>;
  createMany(model: Array<IProductDocument>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductDocumentLookupModel>>>;
  createMany(model: Array<IProductDocument>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductDocumentLookupModel>>>;
  createMany(model: Array<IProductDocument>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments/createMany', {});

    return this.apiClient.create<Array<IProductDocument>, Array<IProductDocumentLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(productID: number, documentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(productID: number, documentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(productID: number, documentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(productID: number, documentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments', {
      productID,
      documentID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IProductDocumentPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IProductDocumentPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IProductDocumentPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IProductDocumentPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments/DeleteMany', {});

    return this.apiClient.post<Array<IProductDocumentPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(productID: number, documentID: number, model: IProductDocumentUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDocumentLookupModel>;
  update(productID: number, documentID: number, model: IProductDocumentUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDocumentLookupModel>>;
  update(productID: number, documentID: number, model: IProductDocumentUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDocumentLookupModel>>;
  update(productID: number, documentID: number, model: IProductDocumentUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments', {
      productID,
      documentID,
    });

    return this.apiClient.update<IProductDocumentUpdateModel, IProductDocumentLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IProductDocumentUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IProductDocumentLookupModel>>;
  updateMany(model: Array<IProductDocumentUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IProductDocumentLookupModel>>>;
  updateMany(model: Array<IProductDocumentUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IProductDocumentLookupModel>>>;
  updateMany(model: Array<IProductDocumentUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments/UpdateMany', {});

    return this.apiClient.update<Array<IProductDocumentUpdateItem>, Array<IProductDocumentLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(productID: number, documentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDocumentLookupModel>;
  get(productID: number, documentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDocumentLookupModel>>;
  get(productID: number, documentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDocumentLookupModel>>;
  get(productID: number, documentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments', {
      productID,
      documentID,
    });

    return this.apiClient.get<IProductDocumentLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByDocument(documentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDocumentsListViewModel>;
  getByDocument(documentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDocumentsListViewModel>>;
  getByDocument(documentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDocumentsListViewModel>>;
  getByDocument(documentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments/GetProductDocumentsByDocument', {
      documentID,
    });

    return this.apiClient.get<IProductDocumentsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IProductDocumentsListViewModel>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IProductDocumentsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IProductDocumentsListViewModel>>;
  getByProduct(productID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('ProductDocuments/GetProductDocumentsByProduct', {
      productID,
    });

    return this.apiClient.get<IProductDocumentsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
