
export interface ISalesTerritoryHistoryLookupModel {
  salesPersonID: number;
  territoryID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesTerritoryHistoryLookupModel implements ISalesTerritoryHistoryLookupModel {
  salesPersonID: number;
  territoryID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesTerritoryHistoryLookupModel>) {
    if (!!init) {
      Object.assign<SalesTerritoryHistoryLookupModel, Partial<SalesTerritoryHistoryLookupModel>>(this, init);
    }
  }
}
