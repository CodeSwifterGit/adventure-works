export interface ISalesPerson {
  salesPersonID: number;
  territoryID: number | null;
  salesQuota: number | null;
  bonus: number;
  commissionPct: number;
  salesYTD: number;
  salesLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SalesPerson implements ISalesPerson {
  salesPersonID: number;
  territoryID: number | null;
  salesQuota: number | null;
  bonus: number;
  commissionPct: number;
  salesYTD: number;
  salesLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesPerson>) {
    if (!!init) {
      Object.assign<SalesPerson, Partial<SalesPerson>>(this, init);
    }
  }
}
