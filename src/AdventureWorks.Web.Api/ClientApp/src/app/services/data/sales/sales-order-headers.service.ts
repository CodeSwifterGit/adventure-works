import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { ISalesOrderHeader } from 'app/models/data/entities/sales/sales-order-header/sales-order-header';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { ISalesOrderHeadersListViewModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-headers-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { Observable } from 'rxjs';

export interface ISalesOrderHeaderPrimaryKey {
  salesOrderID: number;
}

export interface ISalesOrderHeaderUpdateItem extends ISalesOrderHeader {
  requestTarget: ISalesOrderHeaderPrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class SalesOrderHeadersService {
  constructor(protected apiClient: DataService) { }

  create(model: ISalesOrderHeader, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderLookupModel>;
  create(model: ISalesOrderHeader, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderLookupModel>>;
  create(model: ISalesOrderHeader, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderLookupModel>>;
  create(model: ISalesOrderHeader, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders', {});
    options = options || { anonymous: false };

    return this.apiClient.create<ISalesOrderHeader, ISalesOrderHeaderLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<ISalesOrderHeader>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesOrderHeaderLookupModel>>;
  createMany(model: Array<ISalesOrderHeader>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesOrderHeaderLookupModel>>>;
  createMany(model: Array<ISalesOrderHeader>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesOrderHeaderLookupModel>>>;
  createMany(model: Array<ISalesOrderHeader>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/createMany', {});
    options = options || { anonymous: false };

    return this.apiClient.create<Array<ISalesOrderHeader>, Array<ISalesOrderHeaderLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(salesOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(salesOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(salesOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(salesOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders', {
      salesOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<ISalesOrderHeaderPrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<ISalesOrderHeaderPrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<ISalesOrderHeaderPrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<ISalesOrderHeaderPrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/DeleteMany', {});
    options = options || { anonymous: false };

    return this.apiClient.post<Array<ISalesOrderHeaderPrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(salesOrderID: number, model: ISalesOrderHeaderUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderLookupModel>;
  update(salesOrderID: number, model: ISalesOrderHeaderUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderLookupModel>>;
  update(salesOrderID: number, model: ISalesOrderHeaderUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderLookupModel>>;
  update(salesOrderID: number, model: ISalesOrderHeaderUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders', {
      salesOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.update<ISalesOrderHeaderUpdateModel, ISalesOrderHeaderLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<ISalesOrderHeaderUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<ISalesOrderHeaderLookupModel>>;
  updateMany(model: Array<ISalesOrderHeaderUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ISalesOrderHeaderLookupModel>>>;
  updateMany(model: Array<ISalesOrderHeaderUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ISalesOrderHeaderLookupModel>>>;
  updateMany(model: Array<ISalesOrderHeaderUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/UpdateMany', {});
    options = options || { anonymous: false };

    return this.apiClient.update<Array<ISalesOrderHeaderUpdateItem>, Array<ISalesOrderHeaderLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(salesOrderID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeaderLookupModel>;
  get(salesOrderID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeaderLookupModel>>;
  get(salesOrderID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeaderLookupModel>>;
  get(salesOrderID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders', {
      salesOrderID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeaderLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByBillToAddress(billToAddressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByBillToAddress(billToAddressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByBillToAddress(billToAddressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByBillToAddress(billToAddressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByBillToAddress', {
      billToAddressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByShipToAddress(shipToAddressID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByShipToAddress(shipToAddressID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByShipToAddress(shipToAddressID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByShipToAddress(shipToAddressID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByShipToAddress', {
      shipToAddressID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByContact(contactID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByContact', {
      contactID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCreditCard(creditCardID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByCreditCard(creditCardID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByCreditCard(creditCardID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByCreditCard(creditCardID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByCreditCard', {
      creditCardID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCurrencyRate(currencyRateID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByCurrencyRate(currencyRateID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByCurrencyRate(currencyRateID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByCurrencyRate(currencyRateID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByCurrencyRate', {
      currencyRateID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByCustomer(customerID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByCustomer', {
      customerID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getBySalesPerson(salesPersonID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersBySalesPerson', {
      salesPersonID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getBySalesTerritory(territoryID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersBySalesTerritory', {
      territoryID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<ISalesOrderHeadersListViewModel>;
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ISalesOrderHeadersListViewModel>>;
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ISalesOrderHeadersListViewModel>>;
  getByShipMethod(shipMethodID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('SalesOrderHeaders/GetSalesOrderHeadersByShipMethod', {
      shipMethodID,
    });
    options = options || { anonymous: false };

    return this.apiClient.get<ISalesOrderHeadersListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
