
export interface ISalesPersonQuotaHistoryLookupModel {
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

export class SalesPersonQuotaHistoryLookupModel implements ISalesPersonQuotaHistoryLookupModel {
  salesPersonID: number;
  quotaDate: Date | string;
  salesQuota: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesPersonQuotaHistoryLookupModel>) {
    if (!!init) {
      Object.assign<SalesPersonQuotaHistoryLookupModel, Partial<SalesPersonQuotaHistoryLookupModel>>(this, init);
    }
  }
}
