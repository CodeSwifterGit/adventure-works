import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IDocument } from 'app/models/data/entities/production/document/document';
import { IDocumentLookupModel } from 'app/models/data/entities/production/document/document-lookup-model';
import { IDocumentUpdateModel } from 'app/models/data/entities/production/document/document-update-model';
import { IDocumentsListViewModel } from 'app/models/data/entities/production/document/documents-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IDocumentPrimaryKey {
  documentID: number;
}

export interface IDocumentUpdateItem extends IDocument {
  requestTarget: IDocumentPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class DocumentsService {
  constructor(protected apiClient: DataService) {}

  create(model: IDocument, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDocumentLookupModel>;
  create(model: IDocument, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDocumentLookupModel>>;
  create(model: IDocument, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDocumentLookupModel>>;
  create(model: IDocument, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Documents', {});
    options = options || { anonymous: false };

    return this.apiClient.create<IDocument, IDocumentLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IDocument>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IDocumentLookupModel>>;
  createMany(model: Array<IDocument>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IDocumentLookupModel>>>;
  createMany(model: Array<IDocument>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IDocumentLookupModel>>>;
  createMany(model: Array<IDocument>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Documents/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<IDocument>, Array<IDocumentLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(documentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(documentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(documentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(documentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Documents', {
      documentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IDocumentPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IDocumentPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IDocumentPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IDocumentPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Documents/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<IDocumentPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(documentID: number, model: IDocumentUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDocumentLookupModel>;
  update(documentID: number, model: IDocumentUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDocumentLookupModel>>;
  update(documentID: number, model: IDocumentUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDocumentLookupModel>>;
  update(documentID: number, model: IDocumentUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Documents', {
      documentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<IDocumentUpdateModel, IDocumentLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IDocumentUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IDocumentLookupModel>>;
  updateMany(model: Array<IDocumentUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IDocumentLookupModel>>>;
  updateMany(model: Array<IDocumentUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IDocumentLookupModel>>>;
  updateMany(model: Array<IDocumentUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('Documents/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<IDocumentUpdateItem>, Array<IDocumentLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(documentID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDocumentLookupModel>;
  get(documentID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDocumentLookupModel>>;
  get(documentID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDocumentLookupModel>>;
  get(documentID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Documents', {
      documentID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<IDocumentLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getAll(options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IDocumentsListViewModel>;
  getAll(options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IDocumentsListViewModel>>;
  getAll(options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IDocumentsListViewModel>>;
  getAll(options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('Documents/all', {});
    options = options || { anonymous: false };

    return this.apiClient.get<IDocumentsListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
