import { ICustomerLookupModel } from 'app/models/data/entities/sales/customer/customer-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISalesPersonLookupModel } from 'app/models/data/entities/sales/sales-person/sales-person-lookup-model';
import { ISalesTerritoryHistoryLookupModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-lookup-model';
import { IStateProvinceLookupModel } from 'app/models/data/entities/person/state-province/state-province-lookup-model';

export interface ISalesTerritoryLookupModel {
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

export class SalesTerritoryLookupModel implements ISalesTerritoryLookupModel {
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

  constructor(init?: Partial<SalesTerritoryLookupModel>) {
    if (!!init) {
      Object.assign<SalesTerritoryLookupModel, Partial<SalesTerritoryLookupModel>>(this, init);
    }
  }
}
