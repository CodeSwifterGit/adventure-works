import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { ISalesPersonQuotaHistoryUpdateModel } from 'app/models/data/entities/sales/sales-person-quota-history/sales-person-quota-history-update-model';
import { ISalesTerritoryHistoryUpdateModel } from 'app/models/data/entities/sales/sales-territory-history/sales-territory-history-update-model';
import { ISalesTerritoryUpdateModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-update-model';
import { IStoreUpdateModel } from 'app/models/data/entities/sales/store/store-update-model';

export interface ISalesPersonUpdateModel {
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

export class SalesPersonUpdateModel implements ISalesPersonUpdateModel {
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

  constructor(init?: Partial<SalesPersonUpdateModel>) {
    if (!!init) {
      Object.assign<SalesPersonUpdateModel, Partial<SalesPersonUpdateModel>>(this, init);
    }
  }
}
