import { ICustomerUpdateModel } from 'app/models/data/entities/sales/customer/customer-update-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { ISalesPersonUpdateModel } from 'app/models/data/entities/sales/sales-person/sales-person-update-model';
import { ISalesTerritoryHistoryUpdateModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-update-model';
import { IStateProvinceUpdateModel } from 'app/models/data/entities/person/state-province/state-province-update-model';

export interface ISalesTerritoryUpdateModel {
  territoryID: number;
  name: string;
  countryRegionCode: string;
  group: string;
  salesYTD: number;
  salesLastYear: number;
  costYTD: number;
  costLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesTerritoryUpdateModel implements ISalesTerritoryUpdateModel {
  territoryID: number;
  name: string;
  countryRegionCode: string;
  group: string;
  salesYTD: number;
  salesLastYear: number;
  costYTD: number;
  costLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesTerritoryUpdateModel>) {
    if (!!init) {
      Object.assign<SalesTerritoryUpdateModel, Partial<SalesTerritoryUpdateModel>>(this, init);
    }
  }
}
