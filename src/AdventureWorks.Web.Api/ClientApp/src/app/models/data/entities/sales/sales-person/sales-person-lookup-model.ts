
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
