import { ISalesPersonUpdateModel } from 'app/models/data/entities/sales/sales-person/sales-person-update-model';

export interface ISalesPersonQuotaHistoryUpdateModel {
  salesPersonID: number;
  quotaDate: Date | string;
  salesQuota: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesPersonQuotaHistoryUpdateModel implements ISalesPersonQuotaHistoryUpdateModel {
  salesPersonID: number;
  quotaDate: Date | string;
  salesQuota: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesPersonQuotaHistoryUpdateModel>) {
    if (!!init) {
      Object.assign<SalesPersonQuotaHistoryUpdateModel, Partial<SalesPersonQuotaHistoryUpdateModel>>(this, init);
    }
  }
}
