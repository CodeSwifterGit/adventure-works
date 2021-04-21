import { IEmployeeLookupModel } from 'app/models/data/entities/human-resources/employee/employee-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISalesPersonQuotaHistoryLookupModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-lookup-model';
import { ISalesTerritoryHistoryLookupModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-lookup-model';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';
import { IStoreLookupModel } from 'app/models/data/entities/sales/store/store-lookup-model';

export interface ISalesPersonLookupModel {
  salesPersonID: number;
  territoryID: number | null;
  salesQuota: number | null;
  bonus: number;
  commissionPct: number;
  salesYTD: number;
  salesLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesPersonLookupModel implements ISalesPersonLookupModel {
  salesPersonID: number;
  territoryID: number | null;
  salesQuota: number | null;
  bonus: number;
  commissionPct: number;
  salesYTD: number;
  salesLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesPersonLookupModel>) {
    if (!!init) {
      Object.assign<SalesPersonLookupModel, Partial<SalesPersonLookupModel>>(this, init);
    }
  }
}
