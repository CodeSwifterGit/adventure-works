export interface ISalesPersonQuotaHistory {
  salesPersonID: number;
  quotaDate: Date | string;
  salesQuota: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SalesPersonQuotaHistory implements ISalesPersonQuotaHistory {
  salesPersonID: number;
  quotaDate: Date | string;
  salesQuota: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesPersonQuotaHistory>) {
    if (!!init) {
      Object.assign<SalesPersonQuotaHistory, Partial<SalesPersonQuotaHistory>>(this, init);
    }
  }
}
